﻿using System;
using System.Collections.Generic;

namespace B2BTecnology.Financeiro.Entidades
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorGasto { get; set; }
        public decimal ValorPago { get; set; }
        public int ContratoId { get; set; }
        public bool Pago { get; set; }

        public virtual Contrato Contrato { get; set; }
    }
}
