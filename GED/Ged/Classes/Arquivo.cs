
using System.ComponentModel.DataAnnotations.Schema;

namespace Ged.Classes
{
    public class Arquivo : Entity
    {
        public int NumeroVersaoAtual { get; set; }
        public IEnumerable<VersaoArquivo> VersoesArquivo { get; set; }
        [NotMapped]
        public VersaoArquivo? VersaoAtual => VersoesArquivo.FirstOrDefault(x => x.NumeroVersao == NumeroVersaoAtual);
    }
}
