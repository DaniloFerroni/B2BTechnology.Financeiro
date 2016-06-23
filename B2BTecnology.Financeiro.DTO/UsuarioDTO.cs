using System.ComponentModel.DataAnnotations;

namespace B2BTecnology.Financeiro.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Digite o Login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha.")]
        public string Senha { get; set; }
    }
}
