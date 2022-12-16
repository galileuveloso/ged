using Ged.Api.Features.ArquivoFeature.Commands;
using Ged.Classes;

namespace Ged.Api.Extensions
{
    public static class ArquivoExtension
    {
        public static Arquivo GetDominio(this InserirArquivoCommand request)
        {
            Arquivo arquivo = new()
            {
                VersoesArquivo = new List<VersaoArquivo>()
                {
                    new()
                    {
                        ConteudoArquivo = new()
                        {
                            Nome = request.NomeArquivo,
                            Tipo = request.TipoArquivo,
                            Tamanho = request.ConteudoArquivo.Length,
                            Conteudo = request.ConteudoArquivo
                        },
                        NumeroVersao = 1
                    }
                },
                NumeroVersaoAtual = 1
            };

            arquivo.VersoesArquivo.Single().ConteudoArquivo.SetHash();

            return arquivo;
        }

        public static InserirArquivoResponse ToResponseInserir(this Arquivo arquivo)
        {
            return new InserirArquivoResponse
            {
                Id = arquivo.Id,
                DataCadastro = arquivo.DataCadastro,
                NumeroVersao = arquivo.VersaoAtual!.NumeroVersao
            };
        }
    }
}
