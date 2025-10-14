using MySql.Data.MySqlClient;
using QuizApp.Database;
using System.Collections.Generic;

namespace QuizApp.Model.DAO
{
    public class OpcaoDAO
    {
        public void Inserir(Opcao opcao, long idPergunta)
        {
            var con = Conexao.Instancia.Conectar();
            string sql = "INSERT INTO opcoes (texto, correta, id_pergunta) VALUES (@texto, @correta, @id)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@texto", opcao.texto);
            cmd.Parameters.AddWithValue("@correta", opcao.correta);
            cmd.Parameters.AddWithValue("@id", idPergunta);
            cmd.ExecuteNonQuery();
        }

        public List<Opcao> ListarPorPergunta(long idPergunta)
        {
            List<Opcao> lista = new List<Opcao>();
            var con = Conexao.Instancia.Conectar();
            string sql = "SELECT * FROM opcoes WHERE id_pergunta = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", idPergunta);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Opcao o = new Opcao
                {
                    Id = dr.GetInt64("id"),
                    texto = dr.GetString("texto"),
                    correta = dr.GetBoolean("correta")
                };
                lista.Add(o);
            }

            dr.Close();
            return lista;
        }
    }
}
