using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Vendedores Vendedores { get; set; }
    }
}
