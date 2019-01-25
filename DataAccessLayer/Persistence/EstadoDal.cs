using System;
using MySql.Data.MySqlClient;
using BusinessLogicLayer.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Persistence
{
    public class EstadoDal : Connection
    {
        public void Salvar(Estado estado)
        {
            try
            {
                AbrirConexao();
                
                string sql = "INSERT INTO estado(nome, sigla, dtCadastro) " +
                    "VALUES (@nome, @sigla, CURRENT_TIMESTAMP()) ";
                
                command.Parameters.AddWithValue("@nome", estado.Nome);
                command.Parameters.AddWithValue("@nome", estado.Sigla);
                
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }catch(Exception erro)
            {
                throw new Exception("Erro ao Registrar Dado" + erro.Message);

            }finally
            {
                FecharConexao();
            }
        }

        public List<Estado> Listar()
        {
            try
            {
                AbrirConexao();
                string sql = "SELECT* FROM estado";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Estado> listaEstado = new List<Estado>();

                while (dataReader.Read())
                {
                    Estado estado     = new Estado();

                    estado.Id         = Convert.ToInt32(dataReader["Id"]);
                    estado.Nome       = dataReader["Nome"].ToString();
                    estado.Sigla      = dataReader["Sigla"].ToString();
                    estado.DtCadastro = dataReader["DtCadastro"].ToString();
                }

                return listaEstado;

            }
            catch(Exception erro)
            {
                throw new Exception("Erro ao Registrar Dado" + erro.Message);
            }
            finally
            {
                FecharConexao();
            }

        }

        public EstadoDal()
        {
        }
    }
}
