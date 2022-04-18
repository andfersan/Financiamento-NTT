using System;
using System.ComponentModel.DataAnnotations;

namespace FinanciamentoModel.Model
{
    public class ProponenteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool FlagRestricao { get; set; }
        public int IdProposta { get; set; }
        public DateTime DataCadastro { get; set; }
    }

}

