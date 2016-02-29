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
            Assert.Fail();
        }

        [TestMethod()]
        public void Pesquisar()
        {
            ClienteDao clienteDao = new ClienteDao();
            Cliente clientePesquisa = new Cliente() { nomeCliente = "Teste22", cpfCliente = "Teste22", telefonesCliente = "Teste22", enderecoCliente = "Teste22" };

            List<Cliente> lista = clienteDao.Pesquisar(clientePesquisa);
            Debug.Write("Qtd Registros: " + lista.Count());
        }

        [TestMethod()]
        public void InserirCliente()
        {
            
            Cliente clienteInsert = new Cliente() { nomeCliente = "Teste22", cpfCliente = "Teste22", telefonesCliente = "Teste22", enderecoCliente = "Teste22" } ;
            // new ClienteDao().InserirCliente(clienteInsert);
            Debug.Write("Id_ClienteInserido: " + new ClienteDao().InserirCliente(clienteInsert));
        }


        [TestMethod()]
        public void AtualizaCliente()
        {

        }


    }
}