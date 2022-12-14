namespace Ged.Classes
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
