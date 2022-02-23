namespace SindTech.App.ViewModels
{
    public class ReclamacaoViewModel
    {
        public Guid Id { get; set; }
        public Guid MoradorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataReclamacao { get; set; }
        public MoradorViewModel Morador { get; set; }
        public IEnumerable<MoradorViewModel> Moradores { get; set; }
    }
}
