using System;
using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ComissaoService : Financas
    {
        public override List<ComissaoDTO> ComissaoCanal(int? canal, DateTime mes, int vendedor)
        {
            canal = canal ?? vendedor;

            var listaComissao = _pagamentoRepository.PagamentosEfetuadosPorCanal(canal, mes)
                .Select(c => new ComissaoDTO
                {
                    CodigoPagamento = c.IdPagamento,
                    NomeCliente = c.Contrato.Cliente.Nome,
                    ValorPagar = c.ValorPago,//ValorPago(c.Contrato.Vendedores.IdVendedor, mes),
                    Pago = c.Pago,
                    Comissao = Comissao(c.Contrato, canal ?? 0, mes, c),
                }).ToList();
            return listaComissao;
        }

        private decimal ValorPago(int canal, DateTime mes)
        {
            var pagamento = _pagamentoRepository.PagamentoMes(canal, mes);

            return pagamento == null ? 0 : pagamento.ValorPago;
        }

        private decimal Comissao(Contrato contrato, int idVendedor, DateTime mes, Pagamento pagamentos)
        {
            var pagamento = _pagamentoRepository.PagamentoMes(idVendedor, mes);
            var vendedor = _vendedoresRepository.GetVendedores(idVendedor);

            if (pagamento == null) return (((pagamentos.ValorPago - (pagamentos.ValorPago * (decimal)0.06)) * 5) / 100);
            var percentualComissao = contrato.Vendedores.Comissao;
            if (vendedor == null) return 0;

            return vendedor.TipoVendedor == (int)Enumeradores.TipoVendedores.Vendedor && contrato.Vendedores.TipoVendedor == (int)Enumeradores.TipoVendedores.Canal ?
                (((pagamento.ValorPago - (pagamento.ValorPago * (decimal)0.06)) * 5) / 100) :
                (((pagamento.ValorPago - (pagamento.ValorPago * (decimal)0.06)) * percentualComissao) / 100);

        }
    }
}
