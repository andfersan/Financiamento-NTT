using FinanciamentoModel.Model;
using FinanciamentoService.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanciamentoAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class ProponenteController : Controller
    {

        private readonly IProponenteService _proponenteService;
        public ProponenteController(IProponenteService proponenteService)
        {
            _proponenteService = proponenteService;
        }


        [HttpGet]

        public async Task<IEnumerable<ProponenteModel>> buscarTodosProponentes()
        {

            return await _proponenteService.buscarTodosProponentes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProponenteModel>> buscarProponentePorId(int id)
        {
            return await _proponenteService.buscarProponentePorId(id);
        }
        //Endpoints

        [HttpPost]
        public async Task adicionarProponente(ProponenteModel proponente)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://2qiaaxu5yf.execute-api.sa-east-1.amazonaws.com/prod/documentos-requeridos");
            request.Method = HttpMethod.Get;
            request.Headers.Add("x-api-key", "uCmYNtfiC51nbAeDk7DoiwNS9AwpX7r69yiydMx1");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            _proponenteService.adicionarProponente(proponente);

        }

        [HttpPut]
        public void alterarProponente(int id, ProponenteModel proponente)
        {
            _proponenteService.alterarProponente(proponente);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> apagarProponente(int id)
        {
            await _proponenteService.apagarProponente(id);
            return Ok();
        }

    }
}
