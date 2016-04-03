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
            //var enderecoAtual = DbSet.First(c => c.IdEndereco == endereco.IdEndereco);
            //endereco.Estado = endereco.Estado;
            //endereco.Cep = endereco.Cep;
            //endereco.Bairro = endereco.Bairro;
            //endereco.Cidade = endereco.Cidade;
            //endereco.Numero = endereco.Numero;
            //endereco.Rua = endereco.Rua;
            //endereco.Complemento = endereco.Complemento;
            Context.SaveChanges();
        }
    }
}
