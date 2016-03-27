using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ClienteService : Mapeamento
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public ClienteDTO Pesquisar(string documento)
        {
            var cliente = _clienteRepository.GetCliente(documento);

            var clienteDto = Mapper.Map<ClienteDTO>(cliente);
            
            return clienteDto;
        }

        public List<ClienteDTO> Todos()
        {
            var clientes = _clienteRepository.GetAll();

            var clientesDto = Mapper.Map<List<ClienteDTO>>(clientes);

            clientes.ForEach(c => clientesDto.First(cl => cl.IdCliente == c.IdCliente).Contratos.First().NomeVendedor = c.Contratos.First().Vendedores.Nome);

            return clientesDto;
        }

        public IEnumerable<ClienteDTO> Clientes(string nome)
        {
            return Todos().Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()));
        }

        public void Salvar(ClienteDTO cliente)
        {
            var clienteExiste = _clienteRepository.GetCliente(cliente.Documento);

            if (clienteExiste.IdCliente == 0)
                Inserir();
            else
                Alterar(cliente, clienteExiste);
        }

        private void Inserir()
        {
            
        }

        private void Alterar(ClienteDTO clienteAlterado, Cliente cliente)
        {
            
        }
    }
}
