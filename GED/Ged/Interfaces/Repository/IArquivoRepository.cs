using Ged.Classes;

namespace Ged.Interfaces.Repository
{
    public interface IArquivoRepository : IRepository<Arquivo>
    {
        Task<Arquivo> GetArquivo(long id);
    }
}
