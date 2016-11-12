using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Equipamentos
    {
        public int IdEquipamento { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }

        public virtual List<Contrato> Contratos { get; set; }
        public virtual List<EquipamentoContrato> EquipamentoContrato { get; set; }
    }
}
