using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public class VendedoresService : Mapeamento
    {
        private readonly VendedoresRepository _vendedoresRepository = new VendedoresRepository();

        public List<VendedoresDTO> GetAll()
        {
            var vendedores = _vendedoresRepository.Todos();
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(vendedores);

            return vendedoresDto;
        }

        public List<VendedoresDTO> GestoresDeVendas()
        {
            return GetAll().Where(v => v.TipoVendedor == Enumeradores.TipoVendedores.Vendedor.GetHashCode()).ToList();
        }

        public VendedoresDTO GetVendedor(string documento)
        {
            var vendedores = _vendedoresRepository.GetVendedor(documento);
            var vendedoresDto = Mapper.Map<VendedoresDTO>(vendedores);

            return vendedoresDto;
        }

        public IEnumerable<VendedoresDTO> VendedoresPorNome(string nome)
        {
            var vendedores = _vendedoresRepository.Todos().Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()));
            var vendedoresDto = Mapper.Map<List<VendedoresDTO>>(vendedores);

            return vendedoresDto;
        }

        public VendedoresDTO Salvar(VendedoresDTO vendedoresDto)
        {
            var vendedorExiste = _vendedoresRepository.GetVendedor(vendedoresDto.Documento);

            //SalvarContato(vendedoresDto.Contato, vendedorExiste != null ? vendedorExiste.Contato : new Contato());
            SalvarEndereco(vendedoresDto.Endereco, vendedorExiste != null ? vendedorExiste.Endereco : new Endereco());

            if (vendedorExiste == null)
                Inserir(vendedoresDto);
            else
                Alterar(vendedoresDto, vendedorExiste);

            return vendedoresDto;
        }

        private void Inserir(VendedoresDTO vendedoresDto)
        {
            var vendedor = Vendedor(vendedoresDto);
            _vendedoresRepository.Incluir(vendedor);
        }

        private void Alterar(VendedoresDTO vendedoresDto, Vendedores vendedores)
        {
            var vendedorAlteracao = VendedorAlteracao(vendedoresDto, vendedores);
            _vendedoresRepository.Alterar(vendedorAlteracao);
        }

        private Vendedores Vendedor(VendedoresDTO vendedorDto)
        {
            return new Vendedores
            {
                Ativo = vendedorDto.Ativo,
                ContatoId = vendedorDto.Contato.IdContato,
                Documento = vendedorDto.Documento,
                EnderecoId = vendedorDto.Endereco.IdEndereco,
                Nome = vendedorDto.Nome,
                TipoVendedor = vendedorDto.TipoVendedor,
                Comissao = vendedorDto.Comissao,
                SuperiorId = vendedorDto.SuperiorId
            };
        }

        private Vendedores VendedorAlteracao(VendedoresDTO vendedorDto, Vendedores vendedor)
        {
            vendedor.Ativo = vendedorDto.Ativo;
            vendedor.ContatoId = vendedorDto.Contato.IdContato;
            vendedor.Documento = vendedorDto.Documento;
            vendedor.EnderecoId = vendedorDto.Endereco.IdEndereco;
            vendedor.Nome = vendedorDto.Nome;
            vendedor.TipoVendedor = vendedorDto.TipoVendedor;
            vendedor.Comissao = vendedorDto.Comissao;
            vendedor.SuperiorId = vendedorDto.SuperiorId;

            return vendedor;
        }


        //private void SalvarContato(ContatoDTO contatoDto, Contato atual)
        //{
        //    DadosPessoais<ContatoDTO, Contato> contatoService = new ContatoService();
        //    contatoService.Salvar(contatoDto, atual);
        //}

        private void SalvarEndereco(EnderecoDTO enderecoDto, Endereco atual)
        {
            DadosPessoais<EnderecoDTO, Endereco> enderecoService = new EnderecoService();
            enderecoService.Salvar(enderecoDto, atual);
        }

        public void Excluir(int idVendedor)
        {
            _vendedoresRepository.Excluir(idVendedor);
        }
    }
}
