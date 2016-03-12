using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class VendedoresMap : EntityTypeConfiguration<Vendedores>
    {
        public VendedoresMap()
        {
            ToTable("TB_VENDEDORES", "dbo");
            HasKey(v => v.IdVendedor);

            Property(v => v.IdVendedor).HasColumnName("ID_VENDEDOR").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.EnderecoId).HasColumnName("ID_ENDERECO");
            Property(v => v.ContatoId).HasColumnName("ID_CONTATO");
            Property(v => v.Documento).HasMaxLength(14).HasColumnName("DOCUMENTO");
            Property(v => v.Comissao).HasColumnName("COMISSAO");
            Property(v => v.TipoVendedor).HasColumnName("TP_VENDEDOR");
            Property(v => v.Ativo).HasColumnName("FL_ATIVO");
            Property(v => v.Nome).HasMaxLength(500).HasColumnName("NOME");
            Property(v => v.SuperiorId).HasColumnName("ID_SUPERIOR");

            HasKey(c => c.ContatoId)
                .HasRequired(c => c.Contato)
                .WithRequiredDependent(c => c.Vendedores);

            HasKey(c => c.EnderecoId)
                .HasRequired(c => c.Endereco)
                .WithRequiredDependent(c => c.Vendedores);

            HasKey(c => c.SuperiorId)
                .HasRequired(c => c.Superior)
                .WithRequiredDependent();
        }
    }
}
