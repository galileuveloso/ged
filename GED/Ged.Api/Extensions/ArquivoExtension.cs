using Ged.Api.Features.ArquivoFeature.Commands;
using Ged.Api.Features.ArquivoFeature.Queries;
using Ged.Classes;
using Ged.Models;

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
                DataCadastro = DateTime.Now,
                Ativo = true
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

        public static RemoverArquivoResponse ToResponseRemover(this Arquivo arquivo)
        {
            return new RemoverArquivoResponse
            {
                Id = arquivo.Id,
                DataAtualizacao = arquivo.DataAtualizacao!.Value
            };
        }

        public static SelecionarArquivosByIdResponse ToResponseSelecionarArquivos(this IEnumerable<Arquivo> arquivos)
        {
            IList<ArquivoResponse> arquivosResponse = new List<ArquivoResponse>();

            foreach (Arquivo arquivo in arquivos)
            {
                ArquivoResponse arq = new(arquivo.Id);
                foreach (VersaoArquivo versao in arquivo.VersoesArquivo)
                {
                    arq.Versoes.Add(new(versao));
                }
                arquivosResponse.Add(arq);
            }

            return new()
            {
                Arquivos = arquivosResponse
            };
        }

        public static ObterArquivoByIdResponse ToResponseObterArquivo(this Arquivo arquivo)
        {
            ArquivoResponse arquivosResponse = new(arquivo.Id);

            foreach (VersaoArquivo versao in arquivo.VersoesArquivo)
            {
                arquivosResponse.Versoes.Add(new(versao));
            }

            return new()
            {
                Arquivo = arquivosResponse
            };
        }
    }
}
