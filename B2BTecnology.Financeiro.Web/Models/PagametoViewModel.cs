using System.Collections.Generic;
using B2BTecnology.Financeiro.DTO;

namespace B2BTecnology.Financeiro.Web.Models
{
    public class PagametoViewModel
    {
        public PagamentoDTO Pagamento { get; set; }
        public List<PagamentoDTO> Pagamentos { get; set; }
    }
}