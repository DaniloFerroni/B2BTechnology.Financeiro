using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class EnderecoRepository : BaseRepository<B2BSolution, Endereco>
    {
        public void Salvar(Endereco endereco)
        {
            if (endereco.IdEndereco == 0)
                Inserir(endereco);
            else
                Alterar(endereco);

            endereco.IdEndereco = Context.SaveChanges();
        }

        private void Alterar(Endereco endereco)
        {
            var enderecoAtual = DbSet.First(c => c.IdEndereco == endereco.IdEndereco);
            enderecoAtual.Estado = endereco.Estado;
            enderecoAtual.Cep = endereco.Cep;
            enderecoAtual.Bairro = endereco.Bairro;
            enderecoAtual.Cidade = endereco.Cidade;
            enderecoAtual.Numero = endereco.Numero;
            enderecoAtual.Rua = endereco.Rua;
            enderecoAtual.Complemento = endereco.Complemento;
        }
    }
}
