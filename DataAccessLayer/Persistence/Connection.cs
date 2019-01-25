using System;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.Persistence
{
    public class Connection
    {
        protected MySqlConnection connection;           //faz a conexao com o banco
        protected MySqlCommand command;                 //faz os comandos q farão a conexao com o banco
        protected MySqlDataReader dataReader;           //faz a leitura do conteudo do banco
        protected string connectionString;              //



        protected void AbrirConexao()
        {
            try
            {

                string server   = "localhost";
                string user     = "root";
                string database = "clinicasistema";
                string port     = "3306";
                string password = "12345678";

                //server=localhost;user=root;database=clinicasistema;port=3306;password=12345678;
                connectionString = "server=" + server + ";"
                                 + "user=" + user + ";"
                                 + "database=" + database + ";"
                                 + "port=" + port + ";"
                                 + "password=" + password + ";";   

                connection = new MySqlConnection(connectionString);
                connection.Open();


            }catch(Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        protected void FecharConexao()
        {
            try
            {
                connection.Close();
            }catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public Connection()
        {
        }
    }
}
