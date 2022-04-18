using System;

namespace FinanciamentoModel.Model
{
    public class PropostaModel
    {
        public int Id { get; set; }
        public decimal ValorEntrada { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int IdImovel { get; set; }
        public decimal ValorImovel { get; set; }
        public decimal TaxaJuros { get; set; }
        public decimal ValorComEntrada { get; set; }
        public decimal ValorComJuros { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime DataCadastro { get; set; }
        public string SituacaoProposta { get; set; }
        public decimal RendaProponente { get; set; }

    }
}
