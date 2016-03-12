using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Equipes
    {
        public int IdEquipe { get; set; }
        public int VendedoresId { get; set; }
        public int CanalId { get; set; }

        public virtual Vendedores Vendedores { get; set; }
        public virtual List<Vendedores> Canal { get; set; }
    }
}
