using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class EquipamentoMap : EntityTypeConfiguration<Equipamentos>
    {
        public EquipamentoMap()
        {
            ToTable("TB_EQUIPAMENTOS", "dbo");
            HasKey(e => e.IdEquipamento);

            Property(e => e.IdEquipamento).HasColumnName("ID_EQUIPAMENTO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Marca).HasMaxLength(200).HasColumnName("MARCA");
            Property(e => e.Modelo).HasMaxLength(200).HasColumnName("MODELO");
            Property(e => e.NumeroSerie).HasMaxLength(200).HasColumnName("NUMERO_SERIE");
        }
    }
}
