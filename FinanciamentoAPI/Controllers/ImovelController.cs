using FinanciamentoModel;
using FinanciamentoModel.Model;
using FinanciamentoService.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanciamentoAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ImovelController : Controller
    {
        private readonly IImovelService _imovelService;
        public ImovelController(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        [HttpGet]
        public async Task<IEnumerable<ImovelModel>> buscarTodosImoveis()
        {
              return await _imovelService.buscarTodosImoveis();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImovelModel>> buscarImovelPorId(int id)
        {
            return await _imovelService.buscarImovelPorId(id);
        }
       
        //Endpoints

        [HttpPost]
        public async Task adicionarImovel( ImovelModel imovel)
        {
            CepModel responseCep = new CepModel();
            using (var client = new HttpClient())
            {
                string URI = "https://viacep.com.br/ws/" + imovel.Cep + "/json/";
                HttpResponseMessage response = await client.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var dadosCep = await response.Content.ReadAsStringAsync();
                    responseCep = JsonConvert.DeserializeObject<CepModel>(dadosCep);
                    imovel.Endereco = responseCep.Logradouro;
                    imovel.Bairro = responseCep.Bairro;
                    imovel.Cidade = responseCep.Localidade;
                    imovel.Uf = responseCep.Uf;
          
                }
                
               
                _imovelService.adicionarImovel(imovel);
            }
            
        }

        [HttpPut]
        public void alterarImovel(int id,  ImovelModel imovel)
        {
             _imovelService.alterarImovel(imovel);
             
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> apagarImovel(int id)
        {
            await _imovelService.apagarImovel(id);
            return Ok();
        }
    }
}
