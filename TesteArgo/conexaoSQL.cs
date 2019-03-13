using System;
using System.Collections.Generic;

using System.Data.SqlClient; 
using TesteArgo.Models;


namespace TesteArgo
{
    public class ConexaoSQL
    {
        protected SqlConnection conexao;    
        protected SqlCommand command;      
        protected SqlDataReader datareader;    

        protected void OpenConnection() 
        {
            conexao = new SqlConnection
            {
              ConnectionString =
            "Data Source=den1.mssql6.gear.host;" +
            "Initial Catalog=testecore;" +
            "User id=testecore;" +
            "Password=Dz2iI~!U1Edq;"
            };
            conexao.Open();
        }

        protected void CloseConnection() 
        {
            conexao.Close(); 
        }
    }

    public class DestinoDAL : ConexaoSQL
    {
        public List<Destino> GetDestinos()
        {
            try
            {
                OpenConnection(); 
                command = new SqlCommand("select top 10 * from Destino", conexao);
                datareader = command.ExecuteReader();

                List<Destino> lista = new List<Destino>(); 

                while (datareader.Read())
                {
                    Destino destino = new Destino
                    {
                        DestinoId = Convert.ToInt32(datareader["DestinoId"]),
                        Nome = Convert.ToString(datareader["Nome"]),
                        Dia = Convert.ToDateTime(datareader["Dia"])
                    };
                    lista.Add(destino); 
                }

                return lista; 
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar os Destinos: " + e.Message);
            }
            finally
            {
                CloseConnection(); 
            }
        }

        public Destino GetDestino(int id)
        {
            try
            {
                OpenConnection(); 
                command = new SqlCommand("select * from Destino where DestinoId= @id", conexao);
                command.Parameters.AddWithValue("@id", id);
                datareader = command.ExecuteReader();

                if (datareader.Read())
                {
                    Destino destino = new Destino
                    {
                        DestinoId = Convert.ToInt32(datareader["DestinoId"]),
                        Nome = Convert.ToString(datareader["Nome"]),
                        Dia = Convert.ToDateTime(datareader["Dia"])
                    };

                    return destino;    
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter o Destino: " + e.Message);
            }
            finally
            {
                CloseConnection(); 
            }
        }

    }


       
 





}
