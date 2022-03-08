using System.ComponentModel.DataAnnotations;

namespace SindTech.App.ViewModels
{
    public class ReclamacaoViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Morador")]
        public Guid MoradorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
        public MoradorViewModel? Morador { get; set; }
        public IEnumerable<MoradorViewModel>? Moradores { get; set; }
    }
}
