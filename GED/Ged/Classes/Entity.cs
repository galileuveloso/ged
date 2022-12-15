namespace Ged.Classes
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
