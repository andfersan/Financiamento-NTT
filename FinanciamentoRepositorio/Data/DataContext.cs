using FinanciamentoModel;
using FinanciamentoModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciamentoData.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<ProponenteModel> Proponente { get; set; }
        public DbSet<PropostaModel> Proposta { get; set; }
        public DbSet<ImovelModel> Imovel { get; set; }
       

        
    }
}
