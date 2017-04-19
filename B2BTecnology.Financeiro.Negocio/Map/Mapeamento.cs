using AutoMapper;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.Negocio.Map
{
    public class Mapeamento
    {
        public Mapeamento()
        {
            Mapper.CreateMap<Contrato, ContratoDTO>()
                .ForMember(c => c.NomeVendedor, option => option.Ignore());
                //.ForMember(c => c.NomeCliente, option => option.Ignore());
            Mapper.CreateMap<Contato, ContatoDTO>()
                .ForMember(ec => ec.NomeContato, memberOptions => memberOptions.MapFrom(e => e.Nome));
            Mapper.CreateMap<ContatoDTO, Contato>()
                .ForMember(ec => ec.Nome, memberOptions => memberOptions.MapFrom(e => e.NomeContato));

            Mapper.CreateMap<Endereco, EnderecoDTO>();
            Mapper.CreateMap<EnderecoDTO, Endereco>();
            
            Mapper.CreateMap<Cliente, ClienteDTO>();
            Mapper.CreateMap<ClienteDTO, Cliente>();
            
            Mapper.CreateMap<Equipamentos, EquipamentosDTO>();
            Mapper.CreateMap<EquipamentosDTO, Equipamentos>();

            Mapper.CreateMap<Vendedores, VendedoresDTO>().ForMember(c => c.Contrato, option => option.Ignore()); ;
            Mapper.CreateMap<Pagamento, PagamentoDTO>();
            Mapper.CreateMap<Usuario, UsuarioDTO>();
            Mapper.CreateMap<EquipamentoContrato, EquipamentoContratoDTO>().ForMember(ec => ec.Equipamento, memberOptions => memberOptions.MapFrom(e => e.Equipamentos));
            Mapper.CreateMap<ContratoAssinaturaDTO, ContratoAssinaturas>();
            Mapper.CreateMap<ContratoAssinaturas, ContratoAssinaturaDTO>();
        }
    }
}
