using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BTecnology.Financeiro.DTO
{
    public class EquipamentoContratoDTO
    {
        public int EquipamentoContratoId { get; set; }
        public int ContratoId { get; set; }
        public int EquipamentoId { get; set; }

        public virtual EquipamentosDTO Equipamento { get; set; }
    }
}
