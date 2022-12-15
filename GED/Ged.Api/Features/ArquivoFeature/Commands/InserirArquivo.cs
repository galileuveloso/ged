using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces;
using Ged.Interfaces.Repository;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Commands
{
    public class InserirArquivoCommand : IRequest<InserirArquivoResponse>
    {

    }

    public class InserirArquivoResponse
    {

    }

    public class InserirArquivoHandler : IRequestHandler<InserirArquivoCommand, InserirArquivoResponse>
    {
        IRepository<Arquivo> _arquivoRepository;
        IRepository<VersaoArquivo> _versaoRepository;
        IRepository<ConteudoArquivo> _conteudoRepository;

        public InserirArquivoHandler(IRepository<Arquivo> arquivoRepository, IRepository<VersaoArquivo> versaoRepository, IRepository<ConteudoArquivo> conteudoRepository)
        {
            _arquivoRepository = arquivoRepository;
            _versaoRepository = versaoRepository;
            _conteudoRepository = conteudoRepository;
        }

        public async Task<InserirArquivoResponse> Handle(InserirArquivoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirArquivoCommand>());

            Arquivo arquivo = new();
            VersaoArquivo versao = new();
            ConteudoArquivo conteudo = new();

            //insiro os tres
            await _arquivoRepository.AddAsync(arquivo);
            await _versaoRepository.AddAsync(versao);
            await _conteudoRepository.AddAsync(conteudo);

            throw new NotImplementedException();
        }
    }
}
