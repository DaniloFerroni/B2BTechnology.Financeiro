using System;
using System.Collections.Generic;
using B2BTecnology.Financeiro.DTO;

namespace B2BTecnology.Financeiro.Web.Models
{
    public class PagametoViewModel
    {
        public DateTime Mes { get; set; }
        public int ClienteId { get; set; }
        public PagamentoDTO Pagamento { get; set; }
        public List<PagamentoDTO> Pagamentos { get; set; }
    }
}