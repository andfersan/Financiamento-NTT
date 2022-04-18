using FinanciamentoModel;
using FinanciamentoModel.Model;
using FinanciamentoService.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanciamentoAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PropostaController : Controller
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }
        [HttpGet]
        public async Task<IEnumerable<PropostaModel>> buscarTodasPropostas()
        {
            return await _propostaService.buscarTodasPropostas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropostaModel>> buscarPropostaPorId(int id)
        {
            return await _propostaService.buscarPropostaPorId(id);
        }

        [HttpPost]
        public async Task adicionarProposta(PropostaModel proposta)
        {
            TaxaJuros Taxa = new TaxaJuros();

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://2qiaaxu5yf.execute-api.sa-east-1.amazonaws.com/prod/juros-cliente");
            request.Method = HttpMethod.Get;
            request.Headers.Add("x-api-key", "uCmYNtfiC51nbAeDk7DoiwNS9AwpX7r69yiydMx1");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            Taxa = JsonConvert.DeserializeObject<TaxaJuros>(responseString);
            proposta.TaxaJuros = Taxa.Taxa_Juros;

            _propostaService.adicionarProposta(proposta);

        }
        [HttpPut]
        public void alterarProposta(int id, PropostaModel proposta)
        {
            _propostaService.alterarProposta(proposta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PropostaModel>> apagarProposta(int id)
        {
            await _propostaService.apagarProposta(id);
            return Ok();
        }
    }
}
