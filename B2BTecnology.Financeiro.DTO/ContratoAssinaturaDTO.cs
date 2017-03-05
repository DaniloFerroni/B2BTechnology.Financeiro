using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2BTecnology.Financeiro.DTO
{
    public class ContratoAssinaturaDTO
    {
        public int IdContratoAssinatura { get; set; }
        public int IdContrato { get; set; }

        public string Did { get; set; }
        public decimal? AssinaturaDid { get; set; }

        public string Valor0800 { get; set; }
        public decimal? Assinatura0800 { get; set; }

        public string Valor0300 { get; set; }
        public decimal? Assinatura0300 { get; set; }

        public string Valor4000 { get; set; }
        public decimal? Assinatura4000 { get; set; }

        public virtual ContratoDTO Contrato { get; set; }
    }
}
