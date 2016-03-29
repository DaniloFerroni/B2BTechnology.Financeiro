using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public abstract class Financas : Mapeamento
    {
        protected readonly PagamentoRepository _pagamentoRepository = new PagamentoRepository();
        protected readonly VendedoresRepository _vendedoresRepository = new VendedoresRepository();

        public virtual List<ComissaoDTO> ComissaoCanal(string canal, DateTime mes)
        {
            return new List<ComissaoDTO>();
        }

        public List<VendedoresDTO> Vendedores()
        {
            var vendedores = _vendedoresRepository.GetTodos();
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(vendedores);
            return vendedoresDto;
        }

        public List<VendedoresDTO> Canais()
        {
            var canais = _vendedoresRepository.GetTodos().Where(v => v.TipoVendedor == Enumeradores.TipoVendedores.Canal.GetHashCode());
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(canais);
            return vendedoresDto;
        }

        public List<VendedoresDTO> Gerentes()
        {
            var gerentes = _vendedoresRepository.GetTodos().Where(v => v.TipoVendedor == Enumeradores.TipoVendedores.Vendedor.GetHashCode());
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(gerentes);
            return vendedoresDto;
        }

    }
}
