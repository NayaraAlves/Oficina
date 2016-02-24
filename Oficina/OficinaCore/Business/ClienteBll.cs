using OficinaCore.DataAccess;
using OficinaCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OficinaCore.Business
{
    public class ClienteBll
    {
        public List<Cliente> Pesquisar(Cliente criterioPesquisa)
        {
           return  new ClienteDao().Pesquisar(criterioPesquisa);
        }
    }
}
