using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class EnderecoService : DadosPessoais<EnderecoDTO, Endereco>
    {
        private static EnderecoRepository _enderecoRepository;

        public EnderecoService()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        public override void Salvar(EnderecoDTO entidade, Endereco atual)
        {
            if (entidade.IdEndereco == 0)
                Incluir(entidade);
            else
                Alterar(entidade, atual);
        }

        public override void Incluir(EnderecoDTO entidade)
        {
            var endereco = Mapeamento(entidade);

            _enderecoRepository.Incluir(endereco);

            entidade.IdEndereco = endereco.IdEndereco;
        }

        public override void Alterar(EnderecoDTO entidade, Endereco atual)
        {
            EnderecoAtualizado(entidade, atual);

            _enderecoRepository.Alterar(atual);
        }

        private Endereco Mapeamento(EnderecoDTO entidade)
        {
            return new Endereco
            {
                Bairro = entidade.Bairro,
                Cep = entidade.Cep,
                Cidade = entidade.Cidade,
                Complemento = entidade.Complemento,
                Estado = entidade.Estado,
                Numero = entidade.Numero,
                Rua = entidade.Rua
            };
        }

        private void EnderecoAtualizado(EnderecoDTO entidade, Endereco atual)
        {
            atual.Bairro = entidade.Bairro;
            atual.Cep = entidade.Cep;
            atual.Cidade = entidade.Cidade;
            atual.Complemento = entidade.Complemento;
            atual.Estado = entidade.Estado;
            atual.Numero = entidade.Numero;
            atual.Rua = entidade.Rua;
        }
    }
}
