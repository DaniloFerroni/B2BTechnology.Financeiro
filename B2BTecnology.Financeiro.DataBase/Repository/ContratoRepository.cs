using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContratoRepository : BaseRepository<B2BSolution, Contrato>
    {
        public void Incluir(Contrato contrato)
        {
            DbSet.Add(contrato);

            Context.SaveChanges();
        }

        public void Alterar(Contrato contrato)
        {
            var entry = Context.Entry(contrato);
            entry.State = EntityState.Unchanged;
            entry.Property(p => p.CadenciaFixa).IsModified = true;
            entry.Property(p => p.PrazoContratual).IsModified = true;
            entry.Property(p => p.ValorConsumoMinimo).IsModified = true;
            entry.Property(p => p.ValorInstalacao).IsModified = true;
            entry.Property(p => p.ValorMensalidade).IsModified = true;
            entry.Property(p => p.ValorTarifaLdn).IsModified = true;
            entry.Property(p => p.ValorTarifaLocal).IsModified = true;
            entry.Property(p => p.ValorTarifaVc1).IsModified = true;
            entry.Property(p => p.ValorTarifaVc2).IsModified = true;
            entry.Property(p => p.ValorTarifaVc3).IsModified = true;
            entry.Property(p => p.VendedorId).IsModified = true;
            entry.Property(p => p.DiaVencimento).IsModified = true;
            entry.Property(p => p.DataContrato).IsModified = true;
            entry.Property(p => p.ClienteId).IsModified = true;
            entry.Property(p => p.CadenciaMovel).IsModified = true;
            entry.Property(p => p.PlanoId).IsModified = true;
            //entry.Property(p => p.Did).IsModified = true;
            //entry.Property(p => p.AssinaturaDid).IsModified = true;
            //entry.Property(p => p.Valor0800).IsModified = true;
            //entry.Property(p => p.Assinatura0800).IsModified = true;
            //entry.Property(p => p.Valor0300).IsModified = true;
            //entry.Property(p => p.Assinatura0300).IsModified = true;
            //entry.Property(p => p.Valor4000).IsModified = true;
            //entry.Property(p => p.Assinatura4000).IsModified = true;

            Context.SaveChanges();
        }

        public Contrato GetContrato(int idContrato)
        {
            LazyLoadingEnabled();
            return DbSet
                    .Include(c => c.Cliente)
                    .Include(c => c.Cliente.Endereco)
                    .Include(c => c.Cliente.Contatos)
                    .Include(c => c.ContratoAssinaturas)
                    .Include(c => c.Vendedores)
                    .Include(c => c.EquipamentoContrato)
                    .Include("EquipamentoContrato.Equipamentos")
                    .First(c => c.IdContrato == idContrato);
        }

        public List<Contrato> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet
                    .Include(c => c.Cliente)
                    .Include(c => c.Vendedores)
                    .ToList();
        }

        public Contrato GetContratoCliente(int idCliente)
        {
            LazyLoadingEnabled();
            return DbSet.First(c => c.ClienteId == idCliente);
        }
    }
}

