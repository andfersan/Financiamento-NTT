using FinanciamentoInterface.Repositorio;
using FinanciamentoModel;
using FinanciamentoModel.Model;
using FinanciamentoService.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoService
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        public PropostaService(IPropostaRepositorio propostaRepositorio)
        {
            _propostaRepositorio = propostaRepositorio;
        }

        public async Task<IEnumerable<PropostaModel>> buscarTodasPropostas()
        {
            return await _propostaRepositorio.buscarTodasPropostas();
        }

        public async Task<PropostaModel> buscarPropostaPorId(int id)
        {
            return await _propostaRepositorio.buscarPropostaPorId(id);
        }

        public void adicionarProposta(PropostaModel proposta)
        {
            proposta.SituacaoProposta = "Aprovado!!";
            proposta.ValorComEntrada = proposta.ValorImovel - proposta.ValorEntrada;

            // calacular juros compostos
            decimal ValorJuros = Convert.ToDecimal((Convert.ToDouble(proposta.ValorComEntrada) * Math.Pow((Convert.ToDouble(proposta.TaxaJuros) / 12) + 1, 
                                (proposta.QuantidadeParcelas)) * 8.37 / 12) / (Math.Pow(8.37 / 12 + 1, (proposta.QuantidadeParcelas)) - 1));
            // entrada minima de 20%
            double EntradaMinima = Convert.ToDouble(proposta.ValorImovel) * 0.20;

            // renda comprometida em no maximo 30%
            double RendaComprometida = Convert.ToDouble(proposta.RendaProponente) * 0.30;

            proposta.ValorComJuros = proposta.ValorComEntrada + ValorJuros;
            proposta.ValorParcela = proposta.ValorComJuros / proposta.QuantidadeParcelas;

            // validacao de entrada e comprometimento de renda

            if (Convert.ToDouble(proposta.ValorEntrada) < EntradaMinima)
            {
                proposta.SituacaoProposta = "Valor de entrada menor que 20%.";
            }

            if (Convert.ToDouble(proposta.ValorParcela) > RendaComprometida) 
            {
                proposta.SituacaoProposta = "Renda comprometida acima de 30%.";
            }
            _propostaRepositorio.adicionarProposta(proposta);
        }

        public void alterarProposta(PropostaModel proposta)
        {
            _propostaRepositorio.alterarProposta(proposta);
        }

        public async Task apagarProposta(int id)
        {
            await _propostaRepositorio.apagarProposta(id);
        }

    }
}
