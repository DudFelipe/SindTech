namespace SindTech.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            DataCadastro = DateTime.Now;
        }
    }
}

