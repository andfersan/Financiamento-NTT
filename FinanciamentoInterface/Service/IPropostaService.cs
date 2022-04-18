using FinanciamentoModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoService.IServices
{
    public interface IPropostaService
    {
        Task<IEnumerable<PropostaModel>> buscarTodasPropostas();
        Task<PropostaModel> buscarPropostaPorId(int id);
        void adicionarProposta(PropostaModel Proposta);
        void alterarProposta(PropostaModel Proposta);
        Task apagarProposta(int id);
    }

}

