using FinanciamentoModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoInterface.Repositorio
{
    public interface IProponenteRepositorio
    {
        Task<IEnumerable<ProponenteModel>> buscarTodosProponentes();
        Task<ProponenteModel> buscarProponentePorId(int id);
        void adicionarProponente(ProponenteModel proponente);
        void  alterarProponente(ProponenteModel proponente);
        Task apagarProponente(int id);
    }
}
