using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("TB_ENDERECO", "dbo");
            HasKey(e => e.IdEndereco);

            Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Rua).HasMaxLength(200).HasColumnName("RUA");
            Property(e => e.Numero).HasMaxLength(6).HasColumnName("NUMERO");
            Property(e => e.Complemento).HasMaxLength(50).HasColumnName("COMPLEMENTO");
            Property(e => e.Cep).HasMaxLength(8).HasColumnName("CEP");
            Property(e => e.Bairro).HasMaxLength(100).HasColumnName("BAIRRO");
            Property(e => e.Cidade).HasMaxLength(50).HasColumnName("CIDADE");
            Property(e => e.Estado).HasMaxLength(2).HasColumnName("ESTADO");
            
        }
    }
}
