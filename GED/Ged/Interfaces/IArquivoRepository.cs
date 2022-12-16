using Ged.Classes;

namespace Ged.Interfaces
{
    public interface IArquivoRepository
    {
        Task<Arquivo> AddAsync(Arquivo arquivo);
    }
}
