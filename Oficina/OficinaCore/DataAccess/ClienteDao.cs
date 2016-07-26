using Microsoft.Practices.EnterpriseLibrary.Data;
using Npgsql;
using OficinaCore.Entities;
using System;
using System.Collections.Generic;
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

        public Int64 AlterarCliente(Cliente clienteAlterado)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE oficina.cliente");
            sql.AppendLine("SET ");
            sql.AppendLine("    nome_cliente = @nomeCliente ,");
            sql.AppendLine("    cpf_cliente = @cpfCliente ,");
            sql.AppendLine("    telefones_cliente = @telefonesCliente ,");
            sql.AppendLine("    endereco_cliente = @enderecoCliente ");
            sql.AppendLine("WHERE ");
            sql.AppendLine("    id_cliente = @idCliente;");

            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                db.AddInParameter(cmd, "@nomeCliente", DbType.String, clienteAlterado.nomeCliente);
                db.AddInParameter(cmd, "@cpfCliente", DbType.String, clienteAlterado.cpfCliente);
                db.AddInParameter(cmd, "@telefonesCliente", DbType.String, clienteAlterado.telefonesCliente);
                db.AddInParameter(cmd, "@enderecoCliente", DbType.String, clienteAlterado.enderecoCliente);
                db.AddInParameter(cmd, "@idCliente", DbType.Int64, clienteAlterado.idCliente);
                
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        clienteAlterado.idCliente = long.Parse(reader[0].ToString());
                    }
                }

                return clienteAlterado.idCliente;
            }

        }

        public bool DeletarCliente(long idCliente)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("    DELETE FROM oficina.cliente ");
            sql.AppendLine("    WHERE ");
            sql.AppendLine("    id_cliente = "+ idCliente + ";");

            Database db = DatabaseFactory.CreateDatabase("postgres");
            DbCommand cmd = db.GetSqlStringCommand(sql.ToString());

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                return true;
            }
            
        }

        public List<Cliente> Pesquisar(Cliente criterioPesquisa)
        {
            List<Cliente> lista = new List<Cliente>();
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" SELECT ");
            sql.AppendLine("    id_cliente,");
            sql.AppendLine("    nome_cliente,");
            sql.AppendLine("    cpf_cliente,");
            sql.AppendLine("    telefones_cliente,");
            sql.AppendLine("    endereco_cliente");
            sql.AppendLine(" FROM ");
            sql.AppendLine("    oficina.cliente ");
            sql.AppendLine(" WHERE ");

            if (!criterioPesquisa.idCliente.Equals(0) && !criterioPesquisa.idCliente.Equals(""))
            {
                sql.AppendLine("   id_cliente = @idCliente AND ");
            }

            if (!string.IsNullOrEmpty(criterioPesquisa.nomeCliente) && !criterioPesquisa.nomeCliente.Equals(0))
            {
                sql.AppendLine("    nome_cliente = @nomeCliente  AND ");
            }
            
            if (!string.IsNullOrEmpty(criterioPesquisa.cpfCliente) && !criterioPesquisa.cpfCliente.Equals(0))
            {
                sql.AppendLine("    cpf_cliente = @cpfCliente AND ");
            }

            if (!string.IsNullOrEmpty(criterioPesquisa.telefonesCliente) && !criterioPesquisa.telefonesCliente.Equals(0))
            {
                sql.AppendLine("    telefones_cliente = @telefonesCliente AND ");
            }

            if (!string.IsNullOrEmpty(criterioPesquisa.enderecoCliente) && !criterioPesquisa.enderecoCliente.Equals(0))
            {
                sql.AppendLine("    endereco_cliente = @enderecoCliente AND ");
            }

            sql.AppendLine("    1 = 1 ");

            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                if (!criterioPesquisa.idCliente.Equals(0) && !criterioPesquisa.idCliente.Equals(""))
                {
                    db.AddInParameter(cmd, "@idCliente", DbType.Int64, criterioPesquisa.idCliente);
                }

                if (!string.IsNullOrEmpty(criterioPesquisa.nomeCliente) && !criterioPesquisa.nomeCliente.Equals(0))
                {
                    db.AddInParameter(cmd, "@nomeCliente", DbType.String, criterioPesquisa.nomeCliente);
                }

                if (!string.IsNullOrEmpty(criterioPesquisa.cpfCliente) && !criterioPesquisa.cpfCliente.Equals(0))
                {
                    db.AddInParameter(cmd, "@cpfCliente", DbType.String, criterioPesquisa.cpfCliente);
                }

                if (!string.IsNullOrEmpty(criterioPesquisa.telefonesCliente) && !criterioPesquisa.telefonesCliente.Equals(0))
                {
                    db.AddInParameter(cmd, "@telefonesCliente", DbType.String, criterioPesquisa.telefonesCliente);
                }

                if (!string.IsNullOrEmpty(criterioPesquisa.enderecoCliente) && !criterioPesquisa.enderecoCliente.Equals(0))
                {
                    db.AddInParameter(cmd, "@enderecoCliente", DbType.String, criterioPesquisa.enderecoCliente);
                }

                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    lista = (List<Cliente>)CarregarListaEntidade<Cliente>(reader);
                }
            }

            return lista;
        }

    }
}
