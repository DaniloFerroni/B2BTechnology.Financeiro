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

            SalvarContato(cliente.Contato, clienteExiste != null ? clienteExiste.Contato : new Contato());
            SalvarEndereco(cliente.Endereco, clienteExiste != null ? clienteExiste.Endereco : new Endereco());

            if (clienteExiste == null)
            {
                Inserir(cliente);
                clienteExiste = new Cliente();
            }
            else
                Alterar(cliente, clienteExiste);

            var contratoDto = cliente.Contratos.First();

            SalvarEquipamentos(contratoDto.EquipamentoContrato, clienteExiste.Contratos.First().EquipamentoContrato, contratoDto.IdContrato);
        }

        private void Inserir(ClienteDTO clienteDto)
        {
            var cliente = Cliente(clienteDto);
            _clienteRepository.Incluir(cliente);

            var contrato = clienteDto.Contratos.First();
            contrato.ClienteId = cliente.IdCliente;
            SalvarContrato(contrato, new Contrato());
        }

        private void Alterar(ClienteDTO clienteDto, Cliente cliente)
        {
            var clienteAlteracao = ClienteAlteracao(clienteDto, cliente);
            _clienteRepository.Alterar(clienteAlteracao);
            var contrato = clienteDto.Contratos.First();
            SalvarContrato(contrato, cliente.Contratos.First());
        }

        private Cliente Cliente(ClienteDTO clienteDto)
        {
            return new Cliente
            {
                Ativo = clienteDto.Ativo,
                ContatoId = clienteDto.Contato.IdContato,
                Documento = clienteDto.Documento,
                EnderecoId = clienteDto.Endereco.IdEndereco,
                Nome = clienteDto.Nome,
                TipoPessoa = clienteDto.TipoPessoa
            };
        }

        private Cliente ClienteAlteracao(ClienteDTO clienteDto, Cliente cliente)
        {
            cliente.Ativo = clienteDto.Ativo;
            cliente.ContatoId = clienteDto.Contato.IdContato;
            cliente.Documento = clienteDto.Documento;
            cliente.EnderecoId = clienteDto.Endereco.IdEndereco;
            cliente.Nome = clienteDto.Nome;
            cliente.TipoPessoa = clienteDto.TipoPessoa;
            
            return cliente;
        }

        private void SalvarContrato(ContratoDTO contratoDto, Contrato contrato)
        {
            var contratoRepository = new ContratoService();
            contratoRepository.Salvar(contratoDto, contrato);
        }

        private void SalvarContato(ContatoDTO contatoDto, Contato atual)
        {
            DadosPessoais<ContatoDTO, Contato> contatoService = new ContatoService();
            contatoService.Salvar(contatoDto, atual);
        }

        private void SalvarEndereco(EnderecoDTO enderecoDto, Endereco atual)
        {
            DadosPessoais<EnderecoDTO, Endereco> enderecoService = new EnderecoService();
            enderecoService.Salvar(enderecoDto, atual);
        }

        private void SalvarEquipamentos(List<EquipamentoContratoDTO> equipamentosContratoDto, List<EquipamentoContrato> equipamentosContrato, int contratoId)
        {
            var equipamentoContratoRepository = new EquipamentoContratoRepository();

            equipamentosContratoDto = equipamentosContratoDto ?? new List<EquipamentoContratoDTO>();

            var incluidos = equipamentosContratoDto.Where(e => e.EquipamentoContratoId == 0).Select(e => new EquipamentoContrato
            {
                ContratoId = contratoId,
                EquipamentoId = e.EquipamentoId
            }).ToList();

            var deletados = equipamentosContrato.Where(e => !equipamentosContratoDto.Exists(d => d.EquipamentoContratoId == e.EquipamentoContratoId)).ToList();

            equipamentoContratoRepository.Inserir(incluidos);
            equipamentoContratoRepository.Deletar(deletados);
        }
    }
}
