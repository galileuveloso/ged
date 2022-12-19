using Ged.Api.Extensions;
using Ged.Api.Helpers;
using Ged.Classes;
using Ged.Interfaces.Repository;
using MediatR;

namespace Ged.Api.Features.ArquivoFeature.Queries
{
    public class ObterConteudoVersaoAtualByIdQuery : IRequest<ObterConteudoVersaoAtualByIdResponse>
    {
        public long IdArquivo { get; set; }

        public void Validate()
        {
            if (IdArquivo == 0) throw new ArgumentNullException("Nenhum Arquivo informado.");
        }
    }

    public class ObterConteudoVersaoAtualByIdResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public byte[] Conteudo { get; set; }
    }

    public class ObterConteudoVersaoAtualByIdHandler : IRequestHandler<ObterConteudoVersaoAtualByIdQuery, ObterConteudoVersaoAtualByIdResponse>
    {
        private readonly IArquivoRepository _repository;
        public async Task<ObterConteudoVersaoAtualByIdResponse> Handle(ObterConteudoVersaoAtualByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<ObterConteudoVersaoAtualByIdQuery>());

            request.Validate();

            ConteudoArquivo conteudo = await _repository.GetConteudoArquivoAtual(request.IdArquivo);

            return conteudo.ToResponseObterConteudoAtual();
        }
    }
}
