using Ged.Classes;

namespace Ged.Models
{
    public class VersaoArquivoResponse
    {
        public VersaoArquivoResponse(VersaoArquivo versaoArquivo)
        {
            Id = versaoArquivo.Id;
            NumeroVersao = versaoArquivo.NumeroVersao;
            DataCadastro = versaoArquivo.DataCadastro;
            IdConteudo = versaoArquivo.IdConteudoArquivo;
        }
        public long Id { get; set; }
        public int NumeroVersao { get; set; }
        public DateTime DataCadastro { get; set; }
        public long IdConteudo { get; set; }
    }
}
