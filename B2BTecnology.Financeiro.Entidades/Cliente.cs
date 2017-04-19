
using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public int EnderecoId { get; set; }
        public int ContatoId { get; set; }
        public bool Ativo { get; set; }
        public string Apelido { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual List<Contato> Contatos { get; set; }
        public virtual List<Contrato> Contratos { get; set; }
    }
}
