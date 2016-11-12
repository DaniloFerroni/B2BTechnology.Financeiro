using System;
using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public int ClienteId { get; set; }
        public int? EquipamentoId { get; set; }
        public decimal ValorTarifaLocal { get; set; }
        public decimal ValorTarifaLdn { get; set; }
        public decimal ValorTarifaVc1 { get; set; }
        public decimal ValorTarifaVc2 { get; set; }
        public decimal ValorTarifaVc3 { get; set; }
        public decimal ValorConsumoMinimo { get; set; }
        public DateTime DataContrato { get; set; }
        public string CadenciaFixa { get; set; }
        public string CadenciaMovel { get; set; }
        public int DiaVencimento { get; set; }
        public decimal ValorInstalacao { get; set; }
        public int PrazoContratual { get; set; }
        public int VendedorId { get; set; }
        public decimal ValorMensalidade { get; set; }

        public string Did { get; set; }
        public decimal? AssinaturaDid { get; set; }

        public string Valor0800 { get; set; }
        public decimal? Assinatura0800 { get; set; }

        public string Valor0300 { get; set; }
        public decimal? Assinatura0300 { get; set; }

        public string Valor4000 { get; set; }
        public decimal? Assinatura4000 { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Equipamentos Equipamento { get; set; }
        public virtual Vendedores Vendedores { get; set; }
        public virtual List<Pagamento> Pagamentos { get; set; }
        public virtual List<EquipamentoContrato> EquipamentoContrato { get; set; }
        
    }
}
