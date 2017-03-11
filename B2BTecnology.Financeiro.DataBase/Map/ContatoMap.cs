using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("TB_CONTATO", "dbo");
            HasKey(c => c.IdContato);

            Property(c => c.IdContato).HasColumnName("ID_CONTATO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasMaxLength(100).HasColumnName("NOME");
            Property(c => c.Email).HasMaxLength(200).HasColumnName("EMAIL");
            Property(c => c.Telefone).HasMaxLength(10).HasColumnName("TELEFONE");
            Property(c => c.Celular).HasMaxLength(11).HasColumnName("CELULAR");
            Property(c => c.IdTipoContato).HasColumnName("Id_TipoContato");

        }
    }
}
