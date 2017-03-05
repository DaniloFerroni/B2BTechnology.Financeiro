using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class DocumentoMap : EntityTypeConfiguration<Documento>
    {
        public DocumentoMap()
        {
            ToTable("TB_DOCUMENTO", "dbo");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("Id_Documento").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Tipo).HasColumnName("Ds_Documento");
            Property(c => c.Layout).HasColumnName("Ds_layout");
        }
    }
}
