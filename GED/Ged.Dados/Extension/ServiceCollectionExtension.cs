using Ged.Classes;
using Ged.Dados.Repository;
using Ged.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DbContext = Ged.Dados.Repository.DbContext;

namespace Ged.Dados.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IVersaoArquivoRepository), typeof(VersaoArquivoRepository));
            services.AddScoped(typeof(IRepository<ConteudoArquivo>), typeof(Repository<ConteudoArquivo>));
            services.AddScoped(typeof(IArquivoRepository), typeof(ArquivoRepository));
        }

        public static void SetupDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(DbContext).Assembly.FullName)
            ));
        }
    }
}
