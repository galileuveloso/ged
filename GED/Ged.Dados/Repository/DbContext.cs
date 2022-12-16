using Ged.Classes;
using Microsoft.EntityFrameworkCore;

namespace Ged.Dados.Repository
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<ConteudoArquivo> ConteudoArquivo { get; set; }
        public DbSet<VersaoArquivo> VersaoArquivo { get; set; }
    }
}
