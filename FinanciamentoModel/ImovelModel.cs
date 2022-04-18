using System;
using System.ComponentModel.DataAnnotations;

namespace FinanciamentoModel.Model
{
    public class ImovelModel
    {
       
        public int Id { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string InscricaoMunicipalImovel { get; set; }
        public decimal ValorImovel { get; set; }
        public DateTime DataCadastro { get; set; }
       
      
    }

   
   
}
