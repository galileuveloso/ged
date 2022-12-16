using Ged.Classes;
using Ged.Interfaces.Repository;

namespace Ged.Dados.Repository
{
    public class VersaoArquivoRepository : Repository<VersaoArquivo>, IVersaoArquivoRepository
    {
        public VersaoArquivoRepository(DbContext context) : base(context)
        {
        }
    }
}
