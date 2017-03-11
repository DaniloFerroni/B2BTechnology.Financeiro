using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace B2BTecnology.Financeiro.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ é Obrigatório.")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tipo de Pessoa é Obrigatório.")]
        public string TipoPessoa { get; set; }
        public int EnderecoId { get; set; }
        public int ContatoId { get; set; }
        public bool Ativo { get; set; }
        public string Apelido { get; set; }

        public EnderecoDTO Endereco { get; set; }
        public List<ContatoDTO> Contatos { get; set; }
        public List<ContratoDTO> Contratos { get; set; }
        public EquipamentosDTO Equipamento { get; set; }
    }
}