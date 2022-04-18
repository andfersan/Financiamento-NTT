using FinanciamentoInterface.Service;
using FinanciamentoModel;
using Refit;
using System;

namespace FinanciamentoUtil
{
    public class BuscaEndereco
    {
        public CepModel buscaPorCep(string cep)
        {
            CepModel cepRetorno = new CepModel();
            try
            {
                var Cep = RestService.For<ICepService>("http://viacep.com.br");
   
                var Retorno = Cep.GetAddressAsync(cep);
                
                
            }
            catch (Exception)
            {
                
            }
            return cepRetorno;


        }


    }
}
