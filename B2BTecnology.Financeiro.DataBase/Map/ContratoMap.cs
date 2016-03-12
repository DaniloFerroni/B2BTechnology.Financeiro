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

            Property(c => c.IdContrato).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.ClienteId).HasColumnType("ID_CLIENTE");
            Property(c => c.EquipamentoId).HasColumnType("ID_EQUIPAMENTO");
            Property(c => c.ValorConsumoMinimo).HasColumnType("VL_CONSUMO_MINIMO");
            Property(c => c.CadenciaFixa).HasMaxLength(6).HasColumnType("DS_CADENCIA_FIXA");
            Property(c => c.CadenciaMovel).HasMaxLength(6).HasColumnType("DS_CADENCIA_MOVEL");
            Property(c => c.DataContrato).HasColumnType("DT_CONTRATO");
            Property(c => c.DiaVencimento).HasColumnType("DIA_VENCIMENTO");
            Property(c => c.ValorInstalacao).HasColumnType("VL_INSTALACAO");
            Property(c => c.PrazoContratual).HasColumnType("ID_PRAZO_CONTRATUAL");
            Property(c => c.VendedorId).HasColumnType("ID_VENDEDOR");
            Property(c => c.ValorTarifaLocal).HasColumnType("VL_TARIFA_LOCAL");
            Property(c => c.ValorTarifaLdn).HasColumnType("VL_TARIFA_LDN");
            Property(c => c.ValorTarifaVc1).HasColumnType("VL_TARIFA_VC1");
            Property(c => c.ValorTarifaVc2).HasColumnType("VL_TARIFA_VC2");
            Property(c => c.ValorTarifaVc3).HasColumnType("VL_TARIFA_VC3");
            Property(c => c.ValorMensalidade).HasColumnType("VL_MENSALIDADE");

            HasKey(c => c.ClienteId)
                .HasRequired(c => c.Cliente)
                .WithRequiredDependent(c => c.Contrato);

            HasKey(c => c.EquipamentoId)
                .HasRequired(c => c.Equipamentos)
                .WithRequiredDependent(c => c.Contrato);

            HasKey(c => c.VendedorId)
                .HasRequired(c => c.Vendedores)
                .WithRequiredDependent(c => c.Contrato);
        }
    }
}