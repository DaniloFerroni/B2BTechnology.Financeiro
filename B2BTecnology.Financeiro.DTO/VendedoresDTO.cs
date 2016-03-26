using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BTecnology.Financeiro.DTO
{
    public class VendedoresDTO
    {
        public int IdVendedor { get; set; }
        public int EnderecoId { get; set; }
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public decimal Comissao { get; set; }
        public int TipoVendedor { get; set; }
        public bool Ativo { get; set; }
        public int SuperiorId { get; set; }

        public EnderecoDTO Endereco { get; set; }
        public ContatoDTO Contato { get; set; }
        public ContratoDTO Contrato { get; set; }
    }
}
