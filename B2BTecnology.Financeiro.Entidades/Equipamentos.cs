using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Equipamentos
    {
        public int IdEquipamento { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }

        public virtual Contrato Contrato { get; set; }
    }
}
