using Ged.Classes;
using Ged.Interfaces.Repository;

namespace Ged.Dados.Repository
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(DbContext context) : base(context)
        {

        }
    }
}
