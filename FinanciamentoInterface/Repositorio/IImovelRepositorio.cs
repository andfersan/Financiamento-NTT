using FinanciamentoModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoInterface.Repositorio
{
    public interface IImovelRepositorio
    {
        Task<IEnumerable<ImovelModel>> buscarTodosImoveis();
        Task<ImovelModel> buscarImovelPorId(int id);
        void adicionarImovel(ImovelModel imovel);
        void alterarImovel(ImovelModel imovel);
        Task apagarImovel(int id);
        
    }
}
