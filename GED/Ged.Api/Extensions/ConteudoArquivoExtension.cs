using Ged.Classes;
using System.Security.Cryptography;

namespace Ged.Api.Extensions
{
    public static class ConteudoArquivoExtension
    {
        public static void SetHash(this ConteudoArquivo entity) => entity.Hash = SHA512.HashData(entity.Conteudo);
    }
}
