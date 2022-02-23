namespace SindTech.Business.Models
{
    public class Reclamacao : Entity
    {
        public Guid MoradorId { get; set; }
        public string Descricao { get; set; }

        //EF Relations
        public Morador Morador { get; set; }
    }
}
