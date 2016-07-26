using Microsoft.Practices.EnterpriseLibrary.Data;
using Npgsql;
using OficinaCore.Entities;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace OficinaCore.DataAccess
{
    public class ProdutoDao : AbstractDao
    {

        public Int64 InserirProduto(Produto produto)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine(" INSERT INTO oficina.produto ");
            sql.AppendLine(" ( ");
            sql.AppendLine("    id_produto, ");
            sql.AppendLine("    nome_produto, ");
            sql.AppendLine("    fabricante_produto, ");
            sql.AppendLine("    peso_liquido_produto,");
            sql.AppendLine("    detalhes ");
            sql.AppendLine(" )");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" (");
            sql.AppendLine("    NEXTVAL('oficina.produto_id_produto_seq'), ");
            sql.AppendLine("    @nomeProduto, ");
            sql.AppendLine("    @fabricanteProduto, ");
            sql.AppendLine("    @pesoLiqProduto, " );
            sql.AppendLine("    @detalhesProduto ");
            sql.AppendLine(" )");
            sql.AppendLine(" returning id_produto;");

            Database db = DatabaseFactory.CreateDatabase("postgres");
            using (DbCommand cmd = db.GetSqlStringCommand(sql.ToString()))
            {
                db.AddInParameter(cmd, "@nomeProduto", DbType.String, produto.nomeProduto);
                db.AddInParameter(cmd, "@fabricanteProduto", DbType.String, produto.fabricanteProduto);
                db.AddInParameter(cmd, "@pesoLiqProduto", DbType.Int64, produto.pesoLiqProduto);
                db.AddInParameter(cmd, "@detalhesProduto", DbType.String, produto.detalhesProduto);
                
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        produto.idProduto = long.Parse(reader[0].ToString());
                    }
                }

                return produto.idProduto;
            } 
        }

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
                    string cmdSeleciona = "Select * from oficina.produto";

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
