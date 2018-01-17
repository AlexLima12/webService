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
                while (sdr.Read())
                {
                    Cidades cidade = new Cidades(Convert.ToInt32(sdr["Id"]), sdr["Nome"].ToString(), sdr["Estado"].ToString(), Convert.ToInt32(sdr["Habitantes"]));
                    cidades.Add(cidade);
                }

            }
            catch(SqlException e)
            {
                throw new Exception("erro ao ler dados" + e.Message);
            }
            catch(System.Exception ex)
            {
                throw new Exception("erro inesperado do sistema" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return cidades;
        }
    }
}