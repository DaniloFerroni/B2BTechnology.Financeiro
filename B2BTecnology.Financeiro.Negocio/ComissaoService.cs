using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ComissaoService : Financas
    {
        public override List<ComissaoDTO> ComissaoCanal(string canal, DateTime mes)
        {
            int idCanal;
            int.TryParse(canal, out idCanal);

            var codigo = idCanal == 0 ? (int?)null : Convert.ToInt32(canal);

            var listaComissao = _pagamentoRepository.PagamentosEfetuadosPorCanal(codigo, mes)
                .Select(c => new ComissaoDTO
                {
                    CodigoPagamento = c.IdPagamento,
                    NomeCliente = c.Contrato.Cliente.Nome,
                    ValorPagar = ValorPago(c.Contrato.Vendedores.IdVendedor, mes),
                    Pago = c.Pago,
                    Comissao = Comissao(c.Contrato, idCanal, mes),
                });
            return listaComissao.ToList();
        }

        private string ValorPago(int canal, DateTime mes)
        {
            var pagamento = _pagamentoRepository.PagamentoMes(canal, mes);

            return pagamento == null ? "" : pagamento.ValorPago.ToString("C");
        }

        private string Comissao(Contrato contrato, int idVendedor, DateTime mes)
        {
            var pagamento = _pagamentoRepository.PagamentoMes(idVendedor, mes);
            var vendedor = _vendedoresRepository.GetVendedores(idVendedor);

            if (pagamento == null) return "";
            var percentualComissao = contrato.Vendedores.Comissao;
            if (vendedor == null) return "";

            return vendedor.TipoVendedor == (int)Enumeradores.TipoVendedores.Vendedor && contrato.Vendedores.TipoVendedor == (int)Enumeradores.TipoVendedores.Canal ?
                (((pagamento.ValorPago - pagamento.ValorPago * (decimal)0.06) * 5) / 100).ToString("C") :
                (((pagamento.ValorPago - pagamento.ValorPago * (decimal)0.06) * percentualComissao) / 100).ToString("C");
        }
    }
}
