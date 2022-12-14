namespace Ged.Classes
{
    public class Arquivo : Entity
    {
        public int VersaoAtual { get; set; }
        public IEnumerable<VersaoArquivo>? VersaoArquivos { get; set; }
    }
}
