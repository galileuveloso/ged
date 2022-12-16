
namespace Ged.Classes
{
    public class Arquivo : Entity
    {
        public int VersaoAtual { get; set; }
        public IEnumerable<VersaoArquivo>? VersoesArquivo { get; set; }

        public VersaoArquivo? VersaoArquivoAtual => VersoesArquivo?.FirstOrDefault(x => x.NumeroVersao == VersaoAtual);
    }
}
