using FinanciamentoModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoService.IServices
{
    public interface IImovelService
    {
        Task<IEnumerable<ImovelModel>> buscarTodosImoveis();
        Task<ImovelModel> buscarImovelPorId(int id);
        void adicionarImovel(ImovelModel imovel);
        void alterarImovel(ImovelModel imovel);
        Task apagarImovel(int id);
      
    }
}
