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
                            Conteudo = request.ConteudoArquivo,
                            DataCadastro = DateTime.Now
                        },
                        NumeroVersao = 1,
                        DataCadastro = DateTime.Now
                    }
                },
                NumeroVersaoAtual = 1,
                DataCadastro = DateTime.Now
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
                NumeroVersao = arquivo.NumeroVersaoAtual
            };
        }

        public static VersaoArquivo GetNovaVersao(this AtualizarArquivoCommand request, Arquivo arquivo)
        {
            VersaoArquivo novaVersao = new()
            {
                IdArquivo = request.Id,
                ConteudoArquivo = new ConteudoArquivo
                {
                    Nome = request.NomeArquivo,
                    Tipo = request.TipoArquivo,
                    Tamanho = request.ConteudoArquivo.Length,
                    Conteudo = request.ConteudoArquivo,
                    DataCadastro = DateTime.Now
                },
                NumeroVersao = arquivo.NumeroVersaoAtual,
                DataCadastro = DateTime.Now
            };

            novaVersao.ConteudoArquivo.SetHash();

            return novaVersao;
        }

        public static AtualizarArquivoResponse ToResponseAtualizar(this Arquivo arquivo)
        {
            return new AtualizarArquivoResponse
            {
                Id = arquivo.Id,
                DataAtualizacao = arquivo.DataAtualizacao!.Value,
                NumeroVersao = arquivo.NumeroVersaoAtual
            };
        }
    }
}
