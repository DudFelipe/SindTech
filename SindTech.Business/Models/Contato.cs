namespace SindTech.Business.Models
{
    public class Contato : Entity
    {
        public Guid MoradorId { get; set; }
        public TipoContato TipoContato { get; set; }
        public string ValorContato { get; set; }

        //EF Relations
        public Morador Morador { get; set; }
    }
}
