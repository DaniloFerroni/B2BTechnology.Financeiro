using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class ContratoAssinaturasMap : EntityTypeConfiguration<ContratoAssinaturas>
    {
        public ContratoAssinaturasMap()
        {
            ToTable("TB_CONTRATO_ASSINATURAS", "dbo");
            HasKey(c => c.IdContratoAssinatura);

            Property(c => c.IdContratoAssinatura).HasColumnName("ID_CONTRATO_Assinatura").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.IdContrato).HasColumnName("ID_CONTRATO");
            Property(c => c.Did).HasMaxLength(15).HasColumnName("Vl_Did");
            Property(c => c.AssinaturaDid).HasColumnName("Ds_AssinaturaDid");
            Property(c => c.Valor0800).HasMaxLength(15).HasColumnName("Vl_0800");
            Property(c => c.Assinatura0800).HasColumnName("Ds_Assinatura0800");
            Property(c => c.Valor0300).HasMaxLength(15).HasColumnName("Vl_0300");
            Property(c => c.Assinatura0300).HasColumnName("Ds_Assinatura0300");
            Property(c => c.Valor4000).HasMaxLength(15).HasColumnName("Vl_4000");
            Property(c => c.Assinatura4000).HasColumnName("Ds_Assinatura4000");

            HasRequired(c => c.Contrato)
                .WithMany(c => c.ContratoAssinaturas)
                .HasForeignKey(c => c.IdContrato);
        }
    }
}
