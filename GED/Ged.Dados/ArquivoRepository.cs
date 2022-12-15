using Ged.Classes;
using Ged.Dados.Repository;
using Ged.Interfaces;
using Ged.Interfaces.Factory;

namespace Ged.Dados
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
