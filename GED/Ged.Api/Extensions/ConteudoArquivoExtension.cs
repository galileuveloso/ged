using Ged.Api.Features.ArquivoFeature.Queries;
using Ged.Classes;
using System.Security.Cryptography;

namespace Ged.Api.Extensions
{
    public static class ConteudoArquivoExtension
    {
        public static void SetHash(this ConteudoArquivo entity) => entity.Hash = SHA512.HashData(entity.Conteudo);

        public static ObterConteudoVersaoAtualByIdResponse ToResponseObterConteudoAtual(this ConteudoArquivo entity)
        {
            return new ObterConteudoVersaoAtualByIdResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Tipo = entity.Tipo,
                Conteudo = entity.Conteudo
            };
        }
    }
}
