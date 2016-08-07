using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace B2BTecnology.Financeiro.DTO
{
    public class ContratoDTO
    {
        public int IdContrato { get; set; }
        public int ClienteId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Tarifa Local Inválido")]
        [Required(ErrorMessage = "Tarifa Local é Obrigatório.")]
        public decimal ValorTarifaLocal { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Tarifa LDN Inválido")]
        [Required(ErrorMessage = "Tarifa LDN é Obrigatório.")]
        public decimal ValorTarifaLdn { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Tarifa VC1 Inválido")]
        [Required(ErrorMessage = "Tarifa VC1 é Obrigatório.")]
        public decimal ValorTarifaVc1 { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Tarifa VC2 Inválido")]
        [Required(ErrorMessage = "Tarifa VC2 é Obrigatório.")]
        public decimal ValorTarifaVc2 { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Tarifa VC3 Inválido")]
        [Required(ErrorMessage = "Tarifa VC3 é Obrigatório.")]
        public decimal ValorTarifaVc3 { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Valor Consumo Mínimo Inválido")]
        [Required(ErrorMessage = "Consumo Mínimo é Obrigatório.")]
        public decimal? ValorConsumoMinimo { get; set; }

        [Required(ErrorMessage = "Data do Contrato é Obrigatório.")]
        public DateTime? DataContrato { get; set; }

        [Required(ErrorMessage = "Cadência Fixa é Obrigatório.")]
        public string CadenciaFixa { get; set; }

        [Required(ErrorMessage = "Cadência Movel é Obrigatório.")]
        public string CadenciaMovel { get; set; }

        [Required(ErrorMessage = "Dia do Vencimento é Obrigatório.")]
        public int DiaVencimento { get; set; }

        public decimal ValorInstalacao { get; set; }

        [Required(ErrorMessage = "Prazo Contratual é Obrigatório.")]
        public int PrazoContratual { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Vendedor é obrigatório.")]
        [Required(ErrorMessage = "Vendedor é obrigatório.")]
        public int VendedorId { get; set; }
        public decimal? ValorMensalidade { get; set; }

        public string NomeVendedor { get; set; }
        public string NomeCliente { get; set; }

        public decimal? Did { get; set; }
        public string AssinaturaDid { get; set; }

        public decimal? Valor0800 { get; set; }
        public string Assinatura0800 { get; set; }

        public decimal? Valor0300 { get; set; }
        public string Assinatura0300 { get; set; }

        public decimal? Valor4000 { get; set; }
        public string Assinatura4000 { get; set; }

        public List<EquipamentoContratoDTO> EquipamentoContrato { get; set; }

    }
}

