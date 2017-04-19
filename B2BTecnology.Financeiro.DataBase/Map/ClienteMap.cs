using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Map
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("TB_CLIENTE", "dbo");
            HasKey(c => c.IdCliente);

            Property(c => c.IdCliente).HasColumnName("ID_CLIENTE").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasMaxLength(500).HasColumnName("NOME");
            Property(c => c.TipoPessoa).HasMaxLength(2).HasColumnName("TP_PESSOA");
            Property(c => c.EnderecoId).HasColumnName("ID_ENDERECO");
            Property(c => c.ContatoId).HasColumnName("ID_CONTATO");
            Property(c => c.Ativo).HasColumnName("FL_ATIVO");
            Property(c => c.Documento).HasMaxLength(14).HasColumnName("DOCUMENTO");
            Property(c => c.Apelido).HasMaxLength(100).HasColumnName("Nm_Apelido");

            //HasRequired(c => c.Contatos)
            //    .WithMany(c => c.Clientes)
            //    .HasForeignKey(c => c.ContatoId);

            HasRequired(c => c.Endereco)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.EnderecoId);
        }
    }
}
