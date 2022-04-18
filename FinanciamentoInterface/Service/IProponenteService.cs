using FinanciamentoModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoService.IServices
{
    public interface IProponenteService
   {
        Task<IEnumerable<ProponenteModel>> buscarTodosProponentes();
        Task<ProponenteModel> buscarProponentePorId(int id);
        void adicionarProponente(ProponenteModel proponente);
        void alterarProponente(ProponenteModel proponente);
        Task apagarProponente(int id);

    }
}
