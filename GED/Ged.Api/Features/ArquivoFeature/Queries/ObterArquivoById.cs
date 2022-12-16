using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using Ged.Models;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Queries
{
    public class ObterArquivoByIdQuery : IRequest<ObterArquivoByIdResponse>
    {
        public long IdArquivo { get; set; }

        public void Validate()
        {
            if (IdArquivo == 0) throw new ArgumentNullException("Nenhum Arquivo informado.");
        }
    }

    public class ObterArquivoByIdResponse
    {
        public ArquivoResponse Arquivo { get; set; }
    }

    public class ObterArquivoByIdHandler : IRequestHandler<ObterArquivoByIdQuery, ObterArquivoByIdResponse>
    {
        private readonly IArquivoRepository _repository;

        public ObterArquivoByIdHandler(IArquivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ObterArquivoByIdResponse> Handle(ObterArquivoByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<ObterArquivoByIdQuery>());

            request.Validate();

            Arquivo arquivo = await _repository.GetArquivo(request.IdArquivo);

            return arquivo.ToResponseObterArquivo();
        }
    }
}
