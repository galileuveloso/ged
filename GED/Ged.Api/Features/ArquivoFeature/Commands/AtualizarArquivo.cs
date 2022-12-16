using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Commands
{
    public class AtualizarArquivoCommand : IRequest<AtualizarArquivoResponse>
    {
        public long Id { get; set; }
        public byte[] ConteudoArquivo { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }

        public void Validate()
        {
            if (Id == 0) throw new ArgumentNullException("Conteudo do Arquivo Nulo.");
            if (ConteudoArquivo == null) throw new ArgumentNullException("Conteudo do Arquivo Nulo.");
            if (String.IsNullOrEmpty(NomeArquivo)) throw new ArgumentNullException("Nome do Arquivo Nulo ou Vazio.");
            if (String.IsNullOrEmpty(TipoArquivo)) throw new ArgumentNullException("Tipo do Arquivo Nulo ou Vazio.");
        }
    }

    public class AtualizarArquivoResponse
    {
        public long Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int NumeroVersao { get; set; }
    }

    public class AtualizarArquivoHandler : IRequestHandler<AtualizarArquivoCommand, AtualizarArquivoResponse>
    {
        private readonly IArquivoRepository _repository;
        private readonly IVersaoArquivoRepository _versaoRepository;

        public AtualizarArquivoHandler(IArquivoRepository repository, IVersaoArquivoRepository versaoRepository)
        {
            _repository = repository;
            _versaoRepository = versaoRepository;
        }

        public async Task<AtualizarArquivoResponse> Handle(AtualizarArquivoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarArquivoCommand>());

            request.Validate();

            Arquivo arquivo = await _repository.GetArquivo(request.Id);
            arquivo.NumeroVersaoAtual++;

            VersaoArquivo novaVersao = request.GetNovaVersao(arquivo);

            await _repository.UpdateAsync(arquivo);
            await _versaoRepository.AddAsync(novaVersao);
            await _repository.SaveChangesAsync();
            await _versaoRepository.SaveChangesAsync();

            return arquivo.ToResponseAtualizar();
        }
    }
}
