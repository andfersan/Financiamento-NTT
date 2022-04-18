using FinanciamentoData.Data;
using FinanciamentoInterface.Repositorio;
using FinanciamentoModel;
using FinanciamentoModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoRepositorio.Repositorio
{ 

    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly DataContext _context;

        public ImovelRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImovelModel>> buscarTodosImoveis()
        {
            return await _context.Imovel.ToListAsync();
        }

        public async Task<ImovelModel> buscarImovelPorId(int id)
        {
            return await _context.Imovel.FindAsync(id);
        }

        public void  adicionarImovel(ImovelModel imovel)
        {
            _context.Imovel.Add(imovel);
            _context.SaveChanges();
        }

        public void alterarImovel(ImovelModel imovel)
        {
            _context.Imovel.Update(imovel);
            _context.SaveChanges();
        }

        public async Task apagarImovel(int id)
        {
            var imovelToApgar =  _context.Imovel.Find(id);
            _context.Imovel.Remove(imovelToApgar);
            await _context.SaveChangesAsync();
        }

        
    }
}
