
namespace B2BTecnology.Financeiro.Entidades
{
    public class Vendedores
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

        public virtual Endereco Endereco { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual Vendedores Superior { get; set; }
        public virtual Contrato Contrato { get; set; }
    }
}
