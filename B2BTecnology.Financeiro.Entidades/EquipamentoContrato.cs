
using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class EquipamentoContrato
    {
        public int EquipamentoContratoId { get; set; }
        public int ContratoId { get; set; }
        public int EquipamentoId { get; set; }


        public virtual Contrato Contrato { get; set; }
        public virtual Equipamentos Equipamentos { get; set; }

    }
}
