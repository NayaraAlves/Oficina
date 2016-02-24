using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OficinaCore.Entities
{
    public class Cliente
    {
        [Mapping(Column = "id_cliente")]
        public long idCliente { get; set; }

        [Mapping(Column = "nome_cliente")]
        public string nomeCliente { get; set; }

        [Mapping(Column = "data_nascimento")]
        public DateTime dataNascimento { get; set; }
    }
}
