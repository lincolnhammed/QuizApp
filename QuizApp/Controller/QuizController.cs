using QuizApp.Model;
using QuizApp.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Controller
{
    public class QuizController
    {
        PerguntaDAO perguntaDAO = new PerguntaDAO();
        OpcaoDAO opcaoDAO = new OpcaoDAO();

        public List<Pergunta> ObterPerguntas()
        {


            List<Pergunta> perguntas = perguntaDAO.Listar();

            foreach (var pergunta in perguntas)
            {
                pergunta.opcoes = opcaoDAO.ListarPorPergunta(pergunta.Id);
            }

            return perguntas;
        }

        public void AdicionarPerunta(Pergunta pergunta)
        {
            long id = perguntaDAO.Inserir(pergunta);

            foreach (var opcao in pergunta.opcoes)
            {
                opcaoDAO.Inserir(opcao,id);
            }

        }

        public bool VerificaResposta(Opcao opcaoEscolha)
        {
            return opcaoEscolha.correta;
        }
    }
}
