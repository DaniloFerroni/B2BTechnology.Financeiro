using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("TB_USUARIO", "dbo");
            HasKey(e => e.UsuarioId);

            Property(e => e.UsuarioId).HasColumnName("ID_USUARIO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Login).HasMaxLength(30).HasColumnName("NM_LOGIN");
            Property(e => e.Senha).HasMaxLength(100).HasColumnName("DS_SENHA");
        }
    }
}
