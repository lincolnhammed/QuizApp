using MySql.Data.MySqlClient;
using QuizApp.Database;
using System.Collections.Generic;

namespace QuizApp.Model.DAO
{
    public class PerguntaDAO
    {
        public long Inserir(Pergunta pergunta)
        {
            var con = Conexao.Instancia.Conectar();
            string sql = "INSERT INTO perguntas (texto) VALUES (@texto)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@texto", pergunta.texto);
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public List<Pergunta> Listar()
        {
            List<Pergunta> lista = new List<Pergunta>();
            var con = Conexao.Instancia.Conectar();
            string sql = "SELECT * FROM perguntas";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Pergunta p = new Pergunta
                {
                    Id = dr.GetInt64("id"),
                    texto = dr.GetString("texto")
                };
                lista.Add(p);
            }

            dr.Close();
            return lista;
        }
    }
}
