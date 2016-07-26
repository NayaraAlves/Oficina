namespace OficinaCore.Entities
{
    public class Produto
    {
        [Mapping(Column = "id_produto")]
        public long idProduto { get; set; }

        [Mapping(Column = "nome_produto")]
        public string nomeProduto { get; set; }

        [Mapping(Column = "fabricante_produto")]
        public string fabricanteProduto { get; set; }

        [Mapping(Column = "peso_liquido_produto")]
        public long pesoLiqProduto { get; set; }

        [Mapping(Column = "detalhes")]
        public string detalhesProduto { get; set; }
        
    }
}
