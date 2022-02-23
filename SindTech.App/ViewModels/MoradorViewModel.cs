using System.ComponentModel.DataAnnotations;

namespace SindTech.App.ViewModels
{
    public class MoradorViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Número do apartamento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int NumeroApartamento { get; set; }
        
        //public bool Ativo { get; set; }

        [Display(Name = "Tipo de Morador")]
        public int TipoMorador { get; set; }
        public ContatoViewModel Contato { get; set; }
        
        ////public DateTime DataCadastro { get; set; }

        //public IEnumerable<ReclamacaoViewModel> Reclamacoes { get; set; }
    }
}
