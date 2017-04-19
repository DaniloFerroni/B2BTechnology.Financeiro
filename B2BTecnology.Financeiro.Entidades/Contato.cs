using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int IdTipoContato { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Vendedores> Vendedores { get; set; }
    }
}
