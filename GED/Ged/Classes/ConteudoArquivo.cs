using Ged.Enums;

namespace Ged.Classes
{
    public class ConteudoArquivo : Entity
    {
        public byte[]? Conteudo { get; set; }
        public byte[]? Hash { get; set; }
        public HashAlgoritmoEnum HashAlgoritmo { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public long Tamanho { get; set; }
    }
}
