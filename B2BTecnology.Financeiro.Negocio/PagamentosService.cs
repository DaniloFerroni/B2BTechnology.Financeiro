using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class PagamentosService : Financas
    {
        protected readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public List<ClienteDTO> Clientes()
        {
            var clientesService = new ClienteService();
            return clientesService.Todos();
        }

        public PagamentoDTO Detalhe(int clienteId)
        {
            var contratoService = new ContratoService();
            var contratoDto = contratoService.ContratoCliente(clienteId);

            var pagamento = new PagamentoDTO
            {
                ContratoId = contratoDto.IdContrato,
                Contrato = contratoDto
            };

            return pagamento;
        }

        public List<PagamentoDTO> PagamentosEfetuados(DateTime data, int clienteId)
        {
            var pagamentos = _pagamentoRepository.PagamentosPorCliente(clienteId, data);
            
            var pagamentoDto = Mapper.Map<List<PagamentoDTO>>(pagamentos);

            foreach (var pagamento in pagamentoDto)
            {
                pagamento.Contrato.NomeCliente = pagamentos.First(p => pagamento.IdPagamento == p.IdPagamento).Contrato.Cliente.Nome;
            }

            return pagamentoDto;
        }

        public List<PagamentoDTO> Salvar(List<PagamentoDTO> pagamentos, DateTime mes, int clienteId)
        {
            var pagamentosAtuais = _pagamentoRepository.PagamentosPorCliente(clienteId, mes);

            pagamentos = pagamentos ?? new List<PagamentoDTO>();

            Incluir(pagamentos);
            Excluir(pagamentos, pagamentosAtuais);
            Alterar(pagamentos, pagamentosAtuais);

            return PagamentosEfetuados(mes, clienteId);
        }

        private void Incluir(List<PagamentoDTO> pagamentosDto)
        {
            var pagamento = pagamentosDto.Where(p => p.IdPagamento == 0).Select(p => new Pagamento
            {
                ValorPago = p.ValorPago,
                ValorGasto = p.ValorGasto,
                Pago = p.Pago,
                DataPagamento = p.DataPagamento,
                ContratoId = _clienteRepository.GetClienteId(p.Contrato.ClienteId).Contratos.First().IdContrato
            }).ToList();

            if (pagamento.Any())_pagamentoRepository.Incluir(pagamento);
        }

        private void Excluir(List<PagamentoDTO> pagamentosDto, List<Pagamento> pagamentosAtuais)
        {
            var excluidos = pagamentosAtuais.Where(atual => !pagamentosDto.Exists(e => e.IdPagamento != 0 && e.IdPagamento == atual.IdPagamento)).ToList();

            if (excluidos.Any()) _pagamentoRepository.Excluir(excluidos);
        }

        private void Alterar(List<PagamentoDTO> pagamentosDto, List<Pagamento> pagamentosAtuais)
        {
            if (!pagamentosAtuais.Any()) return;

            var pagamentosAlterados = pagamentosDto.Where(p => p.Pago != pagamentosAtuais.First(a => a.IdPagamento == p.IdPagamento).Pago).ToList();

            if (!pagamentosAlterados.Any()) return;

            pagamentosAtuais.ForEach(p => p.Pago = pagamentosAlterados.First(a => a.IdPagamento == p.IdPagamento).Pago);

            _pagamentoRepository.Alterar();
        }
    }
}
