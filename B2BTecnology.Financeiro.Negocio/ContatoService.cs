using AutoMapper;
using B2BTecnology.Financeiro.DataBase;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ContatoService : DadosPessoais<ContatoDTO, Contato>
    {
        private static ContatoRepository _contatoRepository;

        public ContatoService()
        {
            _contatoRepository = new ContatoRepository();
        }

        public override void Salvar(ContatoDTO entidade, Contato atual)
        {
            if (entidade.IdContato == 0)
                Incluir(entidade);
            else
                Alterar(entidade, atual);
        }

        public override void Incluir(ContatoDTO entidade)
        {
            var contato = MapeamentoContato(entidade);

            _contatoRepository.Incluir(contato);

            entidade.IdContato = contato.IdContato;
        }

        public override void Alterar(ContatoDTO entidade, Contato atual)
        {
            ContatoAtualizado(entidade, atual);

            _contatoRepository.Alterar(atual);
        }

        private Contato MapeamentoContato(ContatoDTO contatoDto)
        {
            return new Contato
            {
                Celular = contatoDto.Celular,
                Email = contatoDto.Email,
                Nome = contatoDto.NomeContato,
                Telefone = contatoDto.Telefone,
            };
        }

        private void ContatoAtualizado(ContatoDTO contatoDto, Contato contatoAtual)
        {
            contatoAtual.Celular = contatoDto.Celular;
            contatoAtual.Email = contatoDto.Email;
            contatoAtual.Nome = contatoDto.NomeContato;
            contatoAtual.Telefone = contatoDto.Telefone;
        }
    }
}
