using Microsoft.VisualStudio.TestTools.UnitTesting;
using OficinaCore.DataAccess;
using OficinaCore.Entities;
using System.Diagnostics;

namespace OficinaCoreTests.DataAccess
{
    [TestClass()]
    public class ProdutoDaoTests
    {
        [TestMethod()]
        public void InserirProdutoTest()
        {
            Produto produtoInsert = new Produto() { nomeProduto = "Para-Choque", fabricanteProduto = "Teste1", pesoLiqProduto = 1200, detalhesProduto = "TesteNanay" };
            long idProduto = new ProdutoDao().InserirProduto(produtoInsert);
            Debug.Write("Id_ProdutoInserido: " + idProduto);
        }

        [TestMethod()]
        public void GetTodosProdutosTest()
        {
            ProdutoDao produtosDao = new ProdutoDao();

            produtosDao.GetTodosRegistros();
            Assert.Fail();
        }
    }
}
