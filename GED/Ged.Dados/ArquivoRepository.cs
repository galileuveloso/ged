using Ged.Classes;
using Ged.Dados.Repository;
using Ged.Interfaces;
using Ged.Interfaces.Factory;
using Ged.Interfaces.Repository;

namespace Ged.Dados
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        private readonly IRepository<ConteudoArquivo> _conteudoRepository;
        private readonly IRepository<VersaoArquivo> _versaoRepository;

        public ArquivoRepository(IDatabaseFactory databaseFactory, IRepository<ConteudoArquivo> conteudoRepository, IRepository<VersaoArquivo> versaoRepository) : base(databaseFactory)
        {
            _conteudoRepository = conteudoRepository;
            _versaoRepository = versaoRepository;
        }

        public override async Task<Arquivo> AddAsync(Arquivo arquivo)
        {
            arquivo.SetDataCadastro();
            arquivo.VersaoArquivoAtual?.SetDataCadastro();

            await base.AddAsync(arquivo);
            await _conteudoRepository.AddAsync(arquivo.VersaoArquivoAtual!.ConteudoArquivo!);
            await _versaoRepository.AddAsync(arquivo.VersaoArquivoAtual!);
            //conteudo
            //versao

            return new Arquivo();
        }
    }
}
