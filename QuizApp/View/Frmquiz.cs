using QuizApp.Controller;
using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuizApp.View
{
    public partial class Frmquiz : Form
    {
        private readonly QuizController controller = new QuizController();
        private List<Pergunta> perguntas;
        private int indice = 0;
        private int pontuacao = 0;
        private bool bloqueado=false;

        public Frmquiz()
        {
            InitializeComponent();
            ConfigurarEvento();
            CarregarPergunta();
            MostrarPergunta();
        }

        private void ConfigurarEvento()
        {
            btnOp1.Click += BtnOp_Click;
            btnOp2.Click += BtnOp_Click;
            btnOp3.Click += BtnOp_Click;
            btnOp4.Click += BtnOp_Click;
        }

        private void CarregarPergunta()
        {
            perguntas = controller.ObterPerguntas();
            var rand = new Random();
            perguntas = perguntas.OrderBy(x => rand.Next()).ToList();
            foreach (var p in perguntas)
            {
                p.opcoes = p.opcoes.OrderBy(x => rand.Next()).ToList();
            }
            MessageBox.Show($"Foram carregadas {perguntas.Count} perguntas do banco.");
        }

        private void MostrarPergunta()
        {
            if (indice >= perguntas.Count)
            {
                MessageBox.Show($"Quiz concluído! Pontuação: {pontuacao}/{perguntas.Count}");
                Close();
                return;
            }

            ResetarBotoes();   // limpa cores/estado dos botões
            bloqueado = false; // permite clicar novamente

            var pergunta = perguntas[indice];
            lbl_Pergunta.Text = $"{indice + 1}. {pergunta.texto}";

            if (pergunta.opcoes == null || pergunta.opcoes.Count < 4)
            {
                MessageBox.Show("A pergunta atual não tem 4 opções no banco.");
                Close();
                return;
            }

            btnOp1.Text = pergunta.opcoes[0].texto;
            btnOp1.Tag = pergunta.opcoes[0];

            btnOp2.Text = pergunta.opcoes[1].texto;
            btnOp2.Tag = pergunta.opcoes[1];

            btnOp3.Text = pergunta.opcoes[2].texto;
            btnOp3.Tag = pergunta.opcoes[2];

            btnOp4.Text = pergunta.opcoes[3].texto;
            btnOp4.Tag = pergunta.opcoes[3];

            lbl_pontuacao.Text = $"Pontuação: {pontuacao}";
        }


        private void Frmquiz_Load(object sender, EventArgs e)
        {

        }

        private void BtnOp_Click(object sender,EventArgs e)
        {
            if (bloqueado) return;

            var botao = (Button)sender;
            var opcaoEscolhida = (Opcao)botao.Tag;

            bool correta = controller.VerificaResposta(opcaoEscolhida);


            if (correta) {
                botao.BackColor = Color.LightGreen;
                pontuacao++;
            }
            else
            {
                botao.BackColor = Color.IndianRed;
            }

            lbl_pontuacao.Text = $"Pontuação:{pontuacao}";
            bloqueado = true;

            var timer = new Timer { Interval = 1000 }; // espera 1s
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                indice++;           // próxima pergunta
                MostrarPergunta();  // redesenha
            };
            timer.Start();
        }
        private void ResetarBotoes()
        {
            foreach (var btn in TodosBotoes())
            {
                btn.BackColor = SystemColors.Control;
                btn.Enabled = true;
                btn.Tag = null;   // remove dados da pergunta anterior
                btn.Text = "..."; // placeholder até preencher de novo
            }
        }
        private IEnumerable<Button> TodosBotoes()
        {
            yield return btnOp1;
            yield return btnOp2;
            yield return btnOp3;
            yield return btnOp4;
        }
    }
}
