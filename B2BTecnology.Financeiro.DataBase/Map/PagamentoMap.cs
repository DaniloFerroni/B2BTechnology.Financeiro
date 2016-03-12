using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class PagamentoMap : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoMap()
        {
            ToTable("TB_PAGAMENTO", "dbo");
            HasKey(p => p.IdPagamento);

            Property(p => p.IdPagamento).HasColumnName("ID_PAGAMENTO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.DataPagamento).HasColumnName("DT_PAGAMENTO");
            Property(p => p.ValorGasto).HasColumnName("VL_GASTO");
            Property(p => p.ValorPago).HasColumnName("VL_PAGO");
            Property(p => p.ContratoId).HasColumnName("ID_CONTRATO");
            Property(p => p.Pago).HasColumnName("FL_PAGO");

            HasKey(p => p.ContratoId)
                .HasRequired(p => p.Contrato)
                .WithRequiredDependent(p => p.Pagamento);
        }
    }
}
