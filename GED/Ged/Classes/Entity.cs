namespace Ged.Classes
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public void SetDataCadastro() => DataCadastro = DateTime.Now;
        public void SetDataAtualziacao() => DataAtualizacao = DateTime.Now;
    }
}
