﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class PagamentoRepository: BaseRepository<B2BSolution, Pagamento>
    {
        public List<Pagamento> PagamentosEfetuadosPorCanal(int? canal, DateTime mes)
        {
            return DbSet.Where(p => (canal == null ||
                                     p.Contrato.Vendedores.IdVendedor == canal ||
                                     p.Contrato.Vendedores.SuperiorId == canal) &&
                                    p.DataPagamento == mes).ToList();
        }

        public Pagamento PagamentoMes(int canal, DateTime mes)
        {
            return DbSet.FirstOrDefault(p => p.Contrato.Vendedores.IdVendedor == canal && p.DataPagamento == mes);
        }
    }
}
