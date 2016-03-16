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
            //Cliente clientePesquisa = new Cliente() { nomeCliente = "Teste22", cpfCliente = "Teste22", telefonesCliente = "Teste22", enderecoCliente = "Teste22" };
            Cliente clientePesquisa = new Cliente() { nomeCliente = "Teste22" };
            List<Cliente> lista = clienteDao.Pesquisar(clientePesquisa);
            Debug.Write("Qtd Registros: " + lista.Count());
        }

        [TestMethod()]
        public void InserirCliente()
        {

            Cliente clienteInsert = new Cliente() { nomeCliente = "TesteNAY1503", cpfCliente = "TesteNAY150", telefonesCliente = "Teste22", enderecoCliente = "Teste00" };
            // new ClienteDao().InserirCliente(clienteInsert);
            Debug.Write("Id_ClienteInserido: " + new ClienteDao().InserirCliente(clienteInsert));
        }


        [TestMethod()]
        public void AtualizaCliente()
        {
            Cliente clienteAltera = new Cliente() { idCliente = 1, nomeCliente = "Teste2200000", cpfCliente = "Teste220000", telefonesCliente = "Teste2200000", enderecoCliente = "Teste2200000" };
            Debug.Write("Cliente Alterado: " + new ClienteDao().AlterarCliente(clienteAltera));
        }

        [TestMethod()]
        public void DeletarCliente()
        {
            bool retorno = new ClienteDao().DeletarCliente(5);

            if (retorno)
            {
                Debug.Write("Cliente Deletado!");
            }
            else
            {
                Debug.Write("Erro Encontrado!");
            }
        }
    }
}