using FinanciamentoModel;
using Refit;
using System.Threading.Tasks;

namespace FinanciamentoInterface.Service
{
    public interface ICepService
   {
        [Get("/ws/{cep}/json")]
        Task<CepModel> GetAddressAsync(string cep);
   }
}
