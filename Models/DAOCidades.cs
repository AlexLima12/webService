using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using projetoWebServices.Models;

namespace projetoWebServices
{
    public class DAOCidades
    {
        //string de conexão
        SqlConnection cn = null;

        SqlDataReader sdr = null;

        SqlCommand cmd = null;

        string stringCon = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;User Id=sa;Password=senai@123;";
        public List<Cidades> Listar()
        {
            List<Cidades> cidades = new List<Cidades>();
            try
            {
                //iniciando conexão
                cn = new SqlConnection(stringCon);
                //query e conex]ao
                string sqlQuery = "SELECT * FROM Cidades";
                //executando comando com query e setando em qual conexão executar o comando
                cmd = new SqlCommand(sqlQuery, cn);
                //abrindo conexão
                cn.Open();
                //lendo dados
                sdr = cmd.ExecuteReader();
                //laço para inseriror os dados na lista
                while (sdr.Read())
                {
                    Cidades cidade = new Cidades(Convert.ToInt32(sdr["Id"]), sdr["Nome"].ToString(), sdr["Estado"].ToString(), Convert.ToInt32(sdr["Habitantes"]));
                    cidades.Add(cidade);
                }

            }
            //capturando exceções de sql
            catch (SqlException e)
            {
                //lançando exceções
                throw new Exception("erro ao ler dados" + e.Message);
            }
            //capturando exceções do sistema
            catch (System.Exception ex)
            {
                //lançando exceções do sistema
                throw new Exception("erro inesperado do sistema" + ex.Message);
            }
            //fianlizando
            finally
            {
                //fechanco conexão
                cn.Close();
            }

            //retornando lista
            return cidades;
        }

        public bool Cadastrar(Cidades cidades)
        {
            bool resultado = false;
            try
            {
                //criando conexão
                cn = new SqlConnection(stringCon);
                //query
                string sqlQuery = "INSERT INTO Cidades(Nome,Estado,Habitantes)VALUES(@n,@e,@h)";
                //abrundo conexão
                cn.Open();
                //executando query
                cmd = new SqlCommand(sqlQuery, cn);
                //adicionando parametros na query
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                //adicionando parametros na query
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                //adicionando parametros na query
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);
                //sem query de retorno
                int r = cmd.ExecuteNonQuery();
                //se as alterações forem realizadas
                if (r > 0)
                {
                    //retorn true
                    resultado = true;
                }

                //limpa os parametros 
                cmd.Parameters.Clear();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao cadastrar dados no banco" + e);
            }
            catch (SystemException ex)
            {
                throw new Exception("Erro inesperado do sistema" + ex);
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

        // public bool Atualizar(Cidades cidade)
        // {
        //     bool resultado = false;
        //     try
        //     {
        //         cn = new SqlConnection(stringCon);
        //         string sqlQuery = "UPDATE Cidades SET id=@iNome=@n,Estado=@e,Habitantes=@h WHERE Id = @Id";
        //         cmd = new SqlCommand(sqlQuery, cn);
        //         cmd.Parameters.AddWithValue("@i", cidade.Id);
        //         cmd.Parameters.AddWithValue("");

        //     }
        //     catch
        //     {

        //     }
        //     catch
        //     {

        //     }
        //     finally
        //     {

        //     }
        //     return resultado;
        // }
    }
}