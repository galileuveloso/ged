using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Commands
{
    public class InserirArquivoCommand : IRequest<InserirArquivoResponse>
    {
        public byte[] ConteudoArquivo { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }
    }

    public class InserirArquivoResponse
    {
        public long Id { get; set; }
        public int NumeroVersao { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class InserirArquivoHandler : IRequestHandler<InserirArquivoCommand, InserirArquivoResponse>
    {
        private readonly IArquivoRepository _arquivoRepository;
        public InserirArquivoHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public async Task<InserirArquivoResponse> Handle(InserirArquivoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<InserirArquivoCommand>());

            Arquivo arquivo = request.GetDominio();

            await _arquivoRepository.AddAsync(arquivo);

            throw new NotImplementedException();
        }
    }
}
