using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ContatoService
    {
        private static ContatoRepository _contatoRepository;

        public ContatoService()
        {
            _contatoRepository = new ContatoRepository();
        }

        public void Salvar(List<ContatoDTO> entidades, List<Contato> atual, int idCliente)
        {
            entidades = entidades ?? new List<ContatoDTO>();
            atual = atual ?? new List<Contato>();

            var incluidos = entidades.Where(e => e.IdContato == 0).Select(e => new Contato
            {
                IdCliente = idCliente,
                Email = e.Email,
                Nome = e.NomeContato,
                Telefone = e.Telefone,
                IdTipoContato = e.IdTipoContato
            }).ToList();

            var deletados = atual.Where(e => !entidades.Exists(d => d.IdContato == e.IdContato)).ToList();

            _contatoRepository.Incluir(incluidos);
            _contatoRepository.Excluir(deletados);

            //if (entidade.IdContato == 0)
            //    Incluir(entidade);
            //else
            //    Alterar(entidade, atual);
        }

        //public void Incluir(ContatoDTO entidade)
        //{
        //    var contato = MapeamentoContato(entidade);

        //    _contatoRepository.Incluir(contato);

        //    entidade.IdContato = contato.IdContato;
        //}

        //public void Alterar(ContatoDTO entidade, Contato atual)
        //{
        //    ContatoAtualizado(entidade, atual);

        //    _contatoRepository.Alterar(atual);
        //}

        //private Contato MapeamentoContato(ContatoDTO contatoDto)
        //{
        //    return new Contato
        //    {
        //        Celular = contatoDto.Celular,
        //        Email = contatoDto.Email,
        //        Nome = contatoDto.NomeContato,
        //        Telefone = contatoDto.Telefone,
        //        IdTipoContato = contatoDto.IdTipoContato
        //    };
        //}

        //private void ContatoAtualizado(ContatoDTO contatoDto, Contato contatoAtual)
        //{
        //    contatoAtual.IdTipoContato = contatoDto.IdTipoContato;
        //    contatoAtual.Celular = contatoDto.Celular;
        //    contatoAtual.Email = contatoDto.Email;
        //    contatoAtual.Nome = contatoDto.NomeContato;
        //    contatoAtual.Telefone = contatoDto.Telefone;
        //}
    }
}
