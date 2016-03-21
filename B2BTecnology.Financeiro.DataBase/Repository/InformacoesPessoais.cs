using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class InformacoesPessoais
    {
        public void Salvar(Contato contato, Endereco endereco)
        {
            SalvarContato(contato);
            SalvarEndereco(endereco);
        }

        private void SalvarContato(Contato contato)
        {
            var contatoRepository = new ContatoRepository();
            contatoRepository.Salvar(contato);
        }

        private void SalvarEndereco(Endereco endereco)
        {
            var enderecoRepository = new EnderecoRepository();
            enderecoRepository.Salvar(endereco);
        }
    }
}
