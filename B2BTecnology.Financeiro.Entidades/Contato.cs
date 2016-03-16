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

        public virtual List<Cliente> Clientes { get; set; }
        public virtual List<Vendedores> Vendedores { get; set; }
    }
}
