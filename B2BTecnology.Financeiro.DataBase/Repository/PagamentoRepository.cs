using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class PagamentoRepository: BaseRepository<B2BSolution, Pagamento>
    {
        public List<Pagamento> PagamentosEfetuadosPorCanal(int? vendedor, DateTime mes)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contrato")
                .Include("Contrato.Cliente")
                .Include("Contrato.Vendedores")
                .Where(p => (vendedor == null ||
                             p.Contrato.Vendedores.IdVendedor == vendedor ||
                             p.Contrato.Vendedores.SuperiorId == vendedor) &&
                            p.DataPagamento == mes).ToList();
        }

        public Pagamento PagamentoMes(int canal, DateTime mes)
        {
            return DbSet
                .FirstOrDefault(p => p.Contrato.Vendedores.IdVendedor == canal && p.DataPagamento == mes);
        }

        public List<Pagamento> PagamentosPorCliente(int cliente, DateTime mes)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contrato")
                .Include("Contrato.Cliente")
                .Where(p => p.Contrato.ClienteId == cliente && p.DataPagamento == mes).ToList();
        }

        public void Incluir(List<Pagamento> pagamentos)
        {
            foreach (var pagamento in pagamentos)
            {
                DbSet.Add(pagamento);
            }

            Context.SaveChanges();
        }

        public void Excluir(List<Pagamento> pagamentos)
        {
            foreach (var pagamento in pagamentos)
            {
                DbSet.Remove(pagamento);
            }

            Context.SaveChanges();
        }


        public void Alterar()
        {
            Context.SaveChanges();
        }
    }
}
