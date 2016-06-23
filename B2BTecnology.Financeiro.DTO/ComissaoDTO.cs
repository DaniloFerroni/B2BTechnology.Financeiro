
namespace B2BTecnology.Financeiro.DTO
{
    public class ComissaoDTO
    {
        public int CodigoPagamento { get; set; }
        public string NomeCliente { get; set; }
        public decimal ValorPagar { get; set; }
        public bool Pago { get; set; }
        public decimal Comissao { get; set; }
    }
}
