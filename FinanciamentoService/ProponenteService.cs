using DocumentValidator;
using FinanciamentoInterface.Repositorio;
using FinanciamentoModel;
using FinanciamentoModel.Model;
using FinanciamentoService.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoService
{
    public class ProponenteService : IProponenteService
    {
        private readonly IProponenteRepositorio _proponenteRepositorio;
        public ProponenteService(IProponenteRepositorio proponenteRepositorio)
        {
            _proponenteRepositorio = proponenteRepositorio;
        }

        public async Task<IEnumerable<ProponenteModel>> buscarTodosProponentes()
        {
            return await _proponenteRepositorio.buscarTodosProponentes();
        }

        public async Task<ProponenteModel> buscarProponentePorId(int id)
        {
            return await _proponenteRepositorio.buscarProponentePorId(id);
        }

        public void adicionarProponente(ProponenteModel proponente)
        {
            if(proponente.FlagRestricao == false)
            {
                return;
            }
            _proponenteRepositorio.adicionarProponente(proponente);
        }

        public void alterarProponente(ProponenteModel proponente)
        {
            _proponenteRepositorio.alterarProponente(proponente);
        }

        public async Task apagarProponente(int id)
        {
            await _proponenteRepositorio.apagarProponente(id);
        }
    }
}
