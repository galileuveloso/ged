namespace Ged.Models
{
    public class ArquivoResponse
    {
        public ArquivoResponse(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
        public IList<VersaoArquivoResponse> Versoes { get; set; }
    }
}
