using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class ContratoMap : EntityTypeConfiguration<Contrato>
    {
        public ContratoMap()
        {
            ToTable("TB_CONTRATO", "dbo");
            HasKey(c => c.IdContrato);

            Property(c => c.IdContrato).HasColumnName("ID_CONTRATO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.ClienteId).HasColumnName("ID_CLIENTE");
            Property(c => c.EquipamentoId).HasColumnName("ID_EQUIPAMENTO");
            Property(c => c.ValorConsumoMinimo).HasColumnName("VL_CONSUMO_MINIMO");
            Property(c => c.CadenciaFixa).HasMaxLength(6).HasColumnName("DS_CADENCIA_FIXA");
            Property(c => c.CadenciaMovel).HasMaxLength(6).HasColumnName("DS_CADENCIA_MOVEL");
            Property(c => c.DataContrato).HasColumnName("DT_CONTRATO");
            Property(c => c.DiaVencimento).HasColumnName("DIA_VENCIMENTO");
            Property(c => c.ValorInstalacao).HasColumnName("VL_INSTALACAO");
            Property(c => c.PrazoContratual).HasColumnName("ID_PRAZO_CONTRATUAL");
            Property(c => c.VendedorId).HasColumnName("ID_VENDEDOR");
            Property(c => c.ValorTarifaLocal).HasColumnName("VL_TARIFA_LOCAL");
            Property(c => c.ValorTarifaLdn).HasColumnName("VL_TARIFA_LDN");
            Property(c => c.ValorTarifaVc1).HasColumnName("VL_TARIFA_VC1");
            Property(c => c.ValorTarifaVc2).HasColumnName("VL_TARIFA_VC2");
            Property(c => c.ValorTarifaVc3).HasColumnName("VL_TARIFA_VC3");
            Property(c => c.ValorMensalidade).HasColumnName("VL_MENSALIDADE");

            Property(c => c.Did).HasColumnName("Vl_Did");
            Property(c => c.AssinaturaDid).HasColumnName("Ds_AssinaturaDid");
            Property(c => c.Valor0800).HasColumnName("Vl_0800");
            Property(c => c.Assinatura0800).HasColumnName("Ds_Assinatura0800");
            Property(c => c.Valor0300).HasColumnName("Vl_0300");
            Property(c => c.Assinatura0300).HasColumnName("Ds_Assinatura0300");
            Property(c => c.Valor4000).HasColumnName("Vl_4000");
            Property(c => c.Assinatura4000).HasColumnName("Ds_Assinatura4000");

            HasRequired(c => c.Cliente)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.ClienteId);

            HasRequired(c => c.Vendedores)
                .WithMany(c => c.Contrato)
                .HasForeignKey(c => c.VendedorId);

            HasOptional(c => c.Equipamento)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.EquipamentoId);
        }
    }
}