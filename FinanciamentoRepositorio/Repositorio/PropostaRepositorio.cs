using FinanciamentoData.Data;
using FinanciamentoInterface.Repositorio;
using FinanciamentoModel.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanciamentoRepositorio.Repositorio
{
    public class PropostaRepositorio : IPropostaRepositorio
    {
        private readonly DataContext _context;
        public PropostaRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PropostaModel>> buscarTodasPropostas()
        {
            return await _context.Proposta.ToListAsync();
        }

        public async Task<PropostaModel> buscarPropostaPorId(int id)
        {
            return await _context.Proposta.FindAsync(id);
        }

        public void adicionarProposta(PropostaModel proposta)
        {
            _context.Proposta.Add(proposta);
            _context.SaveChanges();
        }

        public void alterarProposta(PropostaModel proposta)
        {
            _context.Proposta.Update(proposta);
            _context.SaveChanges();
        } 
        
        public async Task apagarProposta(int id)
        {
            var propostaToApagar = _context.Proposta.Find(id);
            _context.Proposta.Remove(propostaToApagar);
            await _context.SaveChangesAsync();
        }

    }
}
