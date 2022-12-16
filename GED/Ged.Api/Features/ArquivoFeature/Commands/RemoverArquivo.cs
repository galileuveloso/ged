using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Commands
{
    public class RemoverArquivoCommand : IRequest<RemoverArquivoResponse>
    {
        public RemoverArquivoCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
        public void Validate()
        {
            if (Id == 0) throw new ArgumentNullException("Conteudo do Arquivo Nulo.");
        }
    }

    public class RemoverArquivoResponse
    {
        public long Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }

    public class RemoverArquivoHandler : IRequestHandler<RemoverArquivoCommand, RemoverArquivoResponse>
    {
        private readonly IArquivoRepository _repository;

        public RemoverArquivoHandler(IArquivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoverArquivoResponse> Handle(RemoverArquivoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<RemoverArquivoCommand>());

            request.Validate();

            Arquivo arquivo = await _repository.GetArquivo(request.Id);

            arquivo.Ativo = false;

            await _repository.UpdateAsync(arquivo);

            await _repository.SaveChangesAsync();

            return arquivo.ToResponseRemover();
        }
    }
}
