using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class EquipamentoContratoMap : EntityTypeConfiguration<EquipamentoContrato>
    {
        public EquipamentoContratoMap()
        {
            ToTable("TB_EQUIPAMENTO_CONTRATO", "dbo");
            HasKey(c => c.EquipamentoContratoId);

            Property(c => c.EquipamentoContratoId).HasColumnName("ID_EQUIPAMENTO_CONTRATO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.ContratoId).HasColumnName("ID_CONTRATO");
            Property(c => c.EquipamentoId).HasColumnName("ID_EQUIPAMENTO");

            HasOptional(c => c.Contrato)
                .WithMany(c => c.Equipamentos)
                .HasForeignKey(c => c.ContratoId);
        }
    }
}
