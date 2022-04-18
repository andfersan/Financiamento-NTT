using FinanciamentoModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoInterface.Repositorio
{
    public interface IPropostaRepositorio
    {
        Task<IEnumerable<PropostaModel>> buscarTodasPropostas();
        Task<PropostaModel> buscarPropostaPorId(int id);
        void adicionarProposta(PropostaModel proposta);
        void alterarProposta(PropostaModel proposta);
        Task apagarProposta(int id);
    }
}
