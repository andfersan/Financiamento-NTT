using FinanciamentoData.Data;
using FinanciamentoInterface.Repositorio;
using FinanciamentoModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoRepositorio.Repositorio
{
    public class ProponenteRepositorio : IProponenteRepositorio
    {
        private readonly DataContext _context;
        public ProponenteRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProponenteModel>> buscarTodosProponentes()
        {
            return await _context.Proponente.ToListAsync();
        }

        public async Task<ProponenteModel> buscarProponentePorId(int id)
        {
            return await _context.Proponente.FindAsync(id);
        }

        public void adicionarProponente(ProponenteModel proponente)
        {
            _context.Proponente.Add(proponente);
            _context.SaveChanges();
        }

        public void alterarProponente(ProponenteModel proponente)
        {
            _context.Proponente.Update(proponente);
            _context.SaveChanges();
        }

        public async Task apagarProponente(int id)
        {
            var proponenteToApagar = _context.Proponente.Find(id);
            _context.Proponente.Remove(proponenteToApagar);
            await _context.SaveChangesAsync();
        }
       
    }
}
