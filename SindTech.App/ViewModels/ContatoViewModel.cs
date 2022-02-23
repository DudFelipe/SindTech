using System.ComponentModel.DataAnnotations;

namespace SindTech.App.ViewModels
{
    public class ContatoViewModel
    {
        public Guid Id { get; set; }
        public Guid MoradorId { get; set; }

        [Display(Name = "Tipo de Contato")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int TipoContato { get; set; }

        [Display(Name = "Valor do Contato")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ValorContato { get; set; }
    }
}
