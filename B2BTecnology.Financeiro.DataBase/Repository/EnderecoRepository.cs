using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class EnderecoRepository : BaseRepository<B2BSolution, Endereco>
    {
        public void Incluir(Endereco endereco)
        {
            DbSet.Add(endereco);
            Context.SaveChanges();
        }

        public void Alterar(Endereco endereco)
        {
            var entry = Context.Entry(endereco);
            entry.State = EntityState.Modified;

            entry.Property(p => p.Bairro).IsModified = true;
            entry.Property(p => p.Cep).IsModified = true;
            entry.Property(p => p.Cidade).IsModified = true;
            entry.Property(p => p.Complemento).IsModified = true;
            entry.Property(p => p.Estado).IsModified = true;
            entry.Property(p => p.Numero).IsModified = true;
            entry.Property(p => p.Rua).IsModified = true;

            Context.SaveChanges();
        }
    }
}
