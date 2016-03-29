using System;

namespace B2BTecnology.Financeiro.DTO
{
    public class PagamentoDTO
    {
        public int IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorGasto { get; set; }
        public decimal ValorPago { get; set; }
        public int ContratoId { get; set; }
        public bool Pago { get; set; }

        public virtual ContratoDTO Contrato { get; set; }
    }
}
