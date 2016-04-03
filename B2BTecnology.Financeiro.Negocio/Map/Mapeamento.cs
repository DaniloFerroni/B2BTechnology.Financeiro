using AutoMapper;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio.Map
{
    public class Mapeamento
    {
        public Mapeamento()
        {
            Mapper.CreateMap<Contrato, ContratoDTO>().ForMember(c => c.NomeVendedor, option => option.Ignore());
            Mapper.CreateMap<Contato, ContatoDTO>();
            Mapper.CreateMap<Endereco, EnderecoDTO>();
            Mapper.CreateMap<Cliente, ClienteDTO>();
            Mapper.CreateMap<Equipamentos, EquipamentosDTO>();
            Mapper.CreateMap<Vendedores, VendedoresDTO>().ForMember(c => c.Contrato, option => option.Ignore()); ;
        }
    }
}
