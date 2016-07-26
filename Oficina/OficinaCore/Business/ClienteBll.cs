using OficinaCore.DataAccess;
using OficinaCore.Entities;
using OficinaCore.Enums;
using OficinaCore.Exceptions;
using System.Collections.Generic;

namespace OficinaCore.Business
{
    public class ClienteBll
    {
        public List<Cliente> Pesquisar(Cliente criterioPesquisa)
        {
           return  new ClienteDao().Pesquisar(criterioPesquisa);
        }

        public void TesteException()
        {
            throw new OficinaCoreException(EnumOficinaCoreErro.USUARIO_INEXISTENTE_SCA);
        }
    }
}
