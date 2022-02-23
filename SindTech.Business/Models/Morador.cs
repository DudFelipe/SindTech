namespace SindTech.Business.Models
{
    public class Morador : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NumeroApartamento { get; set; }
        public TipoMorador TipoMorador { get; set; }
        public DateTime DataCadastro { get; } = DateTime.Now;
        public Contato Contato { get; set; }

        //EF Relations
        public IEnumerable<Reclamacao> Reclamacoes { get; set; }
    }
}
