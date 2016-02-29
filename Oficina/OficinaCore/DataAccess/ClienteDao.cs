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
        public Int64 InserirCliente(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" INSERT INTO oficina.cliente ");
            sql.AppendLine(" ( ");
            sql.AppendLine("    id_cliente, ");
            sql.AppendLine("    nome_cliente, ");
            sql.AppendLine("    cpf_cliente, ");
            sql.AppendLine("    telefones_cliente,");
            sql.AppendLine("    endereco_cliente ");
            sql.AppendLine(" )");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (");
            sql.AppendLine("    NEXTVAL('oficina.cliente_id_cliente_seq'), ");
            sql.AppendLine("    @nomeCliente, ");
            sql.AppendLine("    @cpfCliente, ");
            sql.AppendLine("    @telefonesCliente, ");
            sql.AppendLine("    @enderecoCliente ");
            sql.AppendLine(" )");
            sql.AppendLine(" returning id_cliente;");

            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                db.AddInParameter(cmd, "@nomeCliente", DbType.String, cliente.nomeCliente);
                db.AddInParameter(cmd, "@cpfCliente", DbType.String, cliente.cpfCliente);
                db.AddInParameter(cmd, "@telefonesCliente", DbType.String, cliente.telefonesCliente);
                db.AddInParameter(cmd, "@enderecoCliente", DbType.String, cliente.enderecoCliente);

                //db.EndExecuteNonQuery(cmd);

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        cliente.idCliente = long.Parse(reader[0].ToString());
                    }
                }

                return cliente.idCliente;
            }
        }
        
        public List<Cliente> Pesquisar(Cliente criterioPesquisa)
        {
            List<Cliente> lista = new List<Cliente>();
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" SELECT ");
            sql.AppendLine("    id_cliente," );
            sql.AppendLine("    nome_cliente," );
            sql.AppendLine("    cpf_cliente,");
            sql.AppendLine("    telefones_cliente," );
            sql.AppendLine("    endereco_cliente");
            sql.AppendLine(" FROM ");
            sql.AppendLine("    oficina.cliente ");
            sql.AppendLine(" WHERE ");

            if (!criterioPesquisa.idCliente.Equals(0))
            {
                sql.AppendLine("   id_cliente = @idCliente AND " );
            }

            if (!criterioPesquisa.nomeCliente.Equals(0))
            {
                sql.AppendLine("    nome_cliente = @nomeCliente  AND ");
            }

            if (!criterioPesquisa.cpfCliente.Equals(0))
            {
                sql.AppendLine("    cpf_cliente = @cpfCliente AND ");
            }

            if (!criterioPesquisa.telefonesCliente.Equals(0))
            {
                sql.AppendLine("    telefones_cliente = @telefonesCliente AND ");
            }

            if (!criterioPesquisa.enderecoCliente.Equals(0))
            {
                sql.AppendLine("    endereco_cliente = @enderecoCliente AND ");
            }

            sql.AppendLine("    1 = 1 ");

            //ConfigurationManager.ConnectionStrings["postgres"].ToString()
            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                //if (!criterioPesquisa.idCliente.Equals(0))
                //{
                //    db.AddInParameter(cmd, "@idCliente", DbType.Int64, criterioPesquisa.idCliente);
                //}

                //if (!criterioPesquisa.nomeCliente.Equals(0))
                //{
                //    db.AddInParameter(cmd, "@idCliente", DbType.Int64, criterioPesquisa.nomeCliente);
                //}

                //if (!criterioPesquisa.cpfCliente.Equals(0))
                //{
                    
                //}

                //if (!criterioPesquisa.telefonesCliente.Equals(0))
                //{
                    
                //}

                //if (!criterioPesquisa.enderecoCliente.Equals(0))
                //{
                    
                //}
                
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = (List<Cliente>)CarregarListaEntidade<Cliente>(reader);
                }
            }

            return lista;
        }

        ////Pega todos os registros
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
