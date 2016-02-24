using Microsoft.Practices.EnterpriseLibrary.Data;
using Npgsql;
using OficinaCore.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace OficinaCore.DataAccess
{
    public class ClienteDao : AbstractDao
    {
        public List<Cliente> Pesquisar(Cliente criterioPesquisa)
        {
            List<Cliente> lista = new List<Cliente>();
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT id_cliente, nome_cliente, data_nascimento FROM oficina.cliente  ");

            //ConfigurationManager.ConnectionStrings["postgres"].ToString()
            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                /*
                if (!avisoInformativo.IdAvisoInformativo.Equals(0))
                {
                    db.AddInParameter(cmd, "@ID_AVISO_INFORMATIVO", DbType.Int32, avisoInformativo.IdAvisoInformativo);
                }
                */
                
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = (List<Cliente>)CarregarListaEntidade<Cliente>(reader);
                }
            }

            return lista;
        }

        //Pega todos os registros
        public DataTable GetTodosRegistros()
        {
            NpgsqlConnection pgsqlConnection = null;
            DataTable dt = new DataTable();

            try
            {
                // string connString = String.Format("Server=localhost;Port=5432;User Id=postgres;Password=BmqpzSULuf;Database=Oficina;");
                string connString = "teste";
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexão com o PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from oficina.cliente";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return dt;
        }
    }
}
