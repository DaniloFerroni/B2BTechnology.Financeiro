using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual List<Cliente> Clientes { get; set; }
        public virtual List<Vendedores> Vendedores { get; set; }
    }
}
