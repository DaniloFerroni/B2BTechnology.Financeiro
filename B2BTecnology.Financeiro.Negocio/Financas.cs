﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
using B2BTecnology.Financeiro.Negocio.Map;
using TipoPdf = B2BTecnology.Financeiro.DTO.Enumeradores.TipoPdf;

namespace B2BTecnology.Financeiro.Negocio
{
    public abstract class Financas : Mapeamento
    {
        protected readonly PagamentoRepository _pagamentoRepository = new PagamentoRepository();
        protected readonly VendedoresRepository _vendedoresRepository = new VendedoresRepository();

        public virtual List<ComissaoDTO> ComissaoCanal(int? canal, DateTime mes, int vendedor, decimal imposto)
        {
            return new List<ComissaoDTO>();
        }

        public List<VendedoresDTO> Vendedores()
        {
            var vendedores = _vendedoresRepository.Todos();
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(vendedores);
            return vendedoresDto;
        }

        public List<VendedoresDTO> Canais()
        {
            var canais = _vendedoresRepository.Todos().Where(v => v.TipoVendedor == Enumeradores.TipoVendedores.Canal.GetHashCode());
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(canais);
            return vendedoresDto;
        }

        public List<VendedoresDTO> Gerentes()
        {
            var gerentes = _vendedoresRepository.Todos().Where(v => v.TipoVendedor == Enumeradores.TipoVendedores.Vendedor.GetHashCode());
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(gerentes);
            return vendedoresDto;
        }

        public byte[] GerarArquivo<T>(List<T> pagamentos, string nome, DateTime mes, TipoPdf tipoPdf, decimal imposto)
        {
            var arquivo = new Arquivo();
            return arquivo.GerarPdf(pagamentos, nome, mes, tipoPdf, imposto);
        }

    }
}
