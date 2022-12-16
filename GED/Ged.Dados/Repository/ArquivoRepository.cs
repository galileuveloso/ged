using Ged.Classes;
using Ged.Interfaces.Repository;

namespace Ged.Dados.Repository
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(DbContext context) : base(context)
        {

        }

        public override async Task AddAsync(Arquivo arquivo)
        {
            SetInsertData(arquivo.VersaoAtual!);
            SetInsertData(arquivo.VersaoAtual!);
            SetInsertData(arquivo.VersaoAtual!.ConteudoArquivo);
            await base.AddAsync(arquivo);
        }
    }
}
