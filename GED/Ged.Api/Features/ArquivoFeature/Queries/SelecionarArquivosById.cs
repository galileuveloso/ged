using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using Ged.Models;
using MediatR;
using System.Data.Entity.Core;

namespace Ged.Api.Features.ArquivoFeature.Queries
{
    public class SelecionarArquivosByIdQuery : IRequest<SelecionarArquivosByIdResponse>
    {
        public IEnumerable<long> Ids { get; set; }
        public void Validate()
        {
            if (Ids == null || !Ids.Any()) throw new ArgumentNullException("Nenhum Arquivo informado.");
        }
    }

    public class SelecionarArquivosByIdResponse
    {
        public IList<ArquivoResponse> Arquivos { get; set; }
    }

    public class SelecionarArquivosByIdHandler : IRequestHandler<SelecionarArquivosByIdQuery, SelecionarArquivosByIdResponse>
    {
        private readonly IArquivoRepository _repository;

        public SelecionarArquivosByIdHandler(IArquivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<SelecionarArquivosByIdResponse> Handle(SelecionarArquivosByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarArquivosByIdQuery>());

            request.Validate();

            IEnumerable<Arquivo> arquivos = await _repository.GetAsync(x => request.Ids.Contains(x.Id) && x.Ativo);

            if (!arquivos.Any())
                throw new ObjectNotFoundException("Nenhum Arquivo encontrado.");

            return arquivos.ToResponseSelecionarArquivos();
        }
    }
}
