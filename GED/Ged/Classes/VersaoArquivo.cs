namespace Ged.Classes
{
    public class VersaoArquivo : Entity
    {
        public int NumeroVersao { get; set; }
        public Arquivo Arquivo { get; set; }
        public ConteudoArquivo ConteudoArquivo { get; set; }
    }
}
