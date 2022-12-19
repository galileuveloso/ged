using Ged.Classes;
using Ged.Interfaces.Repository;
using System.Data.Entity.Core;

namespace Ged.Dados.Repository
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(DbContext context) : base(context)
        {

        }

        public async Task<Arquivo> GetArquivo(long id)
        {
            Arquivo arquivo = await GetFirstAsync(x => x.Id == id);

            if (arquivo == null || !arquivo.Ativo)
                throw new ObjectNotFoundException("Arquivo não encontrado.");

            return arquivo;
        }

        public async Task<ConteudoArquivo> GetConteudoArquivoAtual(long id)
        {
            Arquivo arquivo = await GetArquivo(id);

            return arquivo.VersaoAtual!.ConteudoArquivo;
        }
    }
}
