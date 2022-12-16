namespace Ged.Classes
{
    public class VersaoArquivo : Entity
    {
        public int NumeroVersao { get; set; }
        public long IdArquivo { get; set; }
        private Arquivo _Arquivo;
        public virtual Arquivo Arquivo
        {
            get
            {
                return _Arquivo;
            }
            set
            {
                _Arquivo = value;
                IdArquivo = value == null ? 0 : value.Id;
            }
        }
        public long IdConteudoArquivo { get; set; }
        private ConteudoArquivo _ConteudoArquivo;
        public virtual ConteudoArquivo ConteudoArquivo
        {
            get
            {
                return _ConteudoArquivo;
            }
            set
            {
                _ConteudoArquivo = value;
                IdConteudoArquivo = value == null ? 0 : value.Id;
            }
        }
    }
}
