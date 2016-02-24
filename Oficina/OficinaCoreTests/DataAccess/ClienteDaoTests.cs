using Microsoft.VisualStudio.TestTools.UnitTesting;
using OficinaCore.DataAccess;
using OficinaCore.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OficinaCore.DataAccess.Tests
{
    [TestClass()]
    public class ClienteDaoTests
    {
        [TestMethod()]
        public void GetTodosRegistrosTest()
        {
            ClienteDao clienteDao = new ClienteDao();

            clienteDao.GetTodosRegistros();
            // Assert.Fail();
        }

        [TestMethod()]
        public void Pesquisar()
        {
            ClienteDao clienteDao = new ClienteDao();

            List<Cliente> lista = clienteDao.Pesquisar(new Cliente());
            Debug.Write("Qtd Registros: " + lista.Count());
        }
    }
}