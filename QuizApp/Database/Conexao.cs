using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuizApp.Database
{
    public sealed class Conexao
    {
        // Instância única (Singleton)
        private static Conexao instancia = null;
        private static readonly object padlock = new object();

        // Conexão com o banco
        private MySqlConnection conexao;
       
        // Construtor privado impede criar novos objetos fora desta classe
        private Conexao()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizDB"].ConnectionString;
            conexao = new MySqlConnection(connectionString);
        }

        // Método que devolve a instância única
        public static Conexao Instancia
        {
            get
            {
                // Evita problemas em ambiente multithread
                lock (padlock)
                {
                    if (instancia == null)
                    {
                        instancia = new Conexao();
                    }
                    return instancia;
                }
            }
        }

        // Abrir a conexão (apenas se estiver fechada)
        public MySqlConnection Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();

            return conexao;
        }

        // Fechar a conexão
        public void Desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}
