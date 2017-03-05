using System.ComponentModel.DataAnnotations;

namespace B2BTecnology.Financeiro.DTO
{
    public class EnderecoDTO
    {
        public int IdEndereco { get; set; }

        //[Required(ErrorMessage = "Digite a Rua.")]
        public string Rua { get; set; }

        //[Required(ErrorMessage = "Digite o Numero.")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        //[Required(ErrorMessage = "Digite o CEP.")]
        public string Cep { get; set; }

        //[Required(ErrorMessage = "Digite o Bairro.")]
        public string Bairro { get; set; }

        //[Required(ErrorMessage = "Digite a Cidade.")]
        public string Cidade { get; set; }

        //[Required(ErrorMessage = "Digite o Estado.")]
        public string Estado { get; set; }
    }
}