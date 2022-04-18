using FinanciamentoInterface.Repositorio;
using FinanciamentoInterface.Service;
using FinanciamentoModel.Model;
using FinanciamentoRepositorio.Repositorio;
using FinanciamentoService.IServices;
using FinanciamentoUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoService
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepositorio _imovelRepositorio;

        public ImovelService(IImovelRepositorio imovelRepositorio)
        {
            _imovelRepositorio = imovelRepositorio;
        }
        public async Task<IEnumerable<ImovelModel>> buscarTodosImoveis()
        {
            return await _imovelRepositorio.buscarTodosImoveis();
        }

        public async Task<ImovelModel> buscarImovelPorId(int id)
        {
            
            return await _imovelRepositorio.buscarImovelPorId(id);
        }

        public void adicionarImovel(ImovelModel imovel)
        {
            int QuantidadeProponente = 0;
            BuscaEndereco end = new BuscaEndereco();
            end.buscaPorCep("");
            _imovelRepositorio.adicionarImovel(imovel);

            if(QuantidadeProponente > 2)
            {

            }
        }
        public void alterarImovel(ImovelModel imovel)
        {
            _imovelRepositorio.alterarImovel(imovel);
        }
        public async Task apagarImovel(int id)
        {
            await _imovelRepositorio.apagarImovel(id);
        }

        

       

       
    }
}
