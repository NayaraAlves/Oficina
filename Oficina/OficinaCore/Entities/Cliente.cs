namespace OficinaCore.Entities
{
    public class Cliente
    {
        [Mapping(Column = "id_cliente")]
        public long idCliente { get; set; }

        [Mapping(Column = "nome_cliente")]
        public string nomeCliente { get; set; }

        [Mapping(Column = "cpf_cliente")]
        public string cpfCliente { get; set; }

        [Mapping(Column = "telefones_cliente")]
        public string telefonesCliente { get; set; }

        [Mapping(Column = "endereco_cliente")]
        public string enderecoCliente { get; set; }

    }
}
