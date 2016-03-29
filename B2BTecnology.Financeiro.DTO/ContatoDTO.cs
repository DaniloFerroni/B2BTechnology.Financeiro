using System.ComponentModel.DataAnnotations;

namespace B2BTecnology.Financeiro.DTO
{
    public class ContatoDTO
    {
        public int IdContato { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Contato.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Required(ErrorMessage = "Digite o E-mail do Contato.")]
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Celular { get; set; }
    }
}