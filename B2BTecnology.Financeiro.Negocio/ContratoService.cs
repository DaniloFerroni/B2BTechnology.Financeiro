using System;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public class ContratoService : Mapeamento
    {
        private static readonly ContratoRepository _contratoRepository = new ContratoRepository();

        public void Salvar(ContratoDTO contratoDto, Contrato contrato)
        {
            if(contratoDto.IdContrato == 0)
                Incluir(contratoDto);
            else
                Alterar(contratoDto, contrato);
        }

        public void Incluir(ContratoDTO contratoDto)
        {
            var contrato = ObjetoContrato(contratoDto);
            _contratoRepository.Incluir(contrato);
        }

        public void Alterar(ContratoDTO contratoDto, Contrato contrato)
        {
            contrato = _contratoRepository.GetContrato(contratoDto.IdContrato);
            ContratoAtualizado(contratoDto, contrato);

            _contratoRepository.Alterar(contrato);
        }

        private Contrato ObjetoContrato(ContratoDTO contratoDto)
        {
            return new Contrato
            {
                CadenciaFixa = contratoDto.CadenciaFixa,
                PrazoContratual = contratoDto.PrazoContratual,
                ValorConsumoMinimo = (decimal)contratoDto.ValorConsumoMinimo,
                ValorInstalacao = contratoDto.ValorInstalacao,
                ValorMensalidade = (decimal)contratoDto.ValorMensalidade,
                ValorTarifaLdn = contratoDto.ValorTarifaLdn,
                ValorTarifaLocal = contratoDto.ValorTarifaLocal,
                ValorTarifaVc1 = contratoDto.ValorTarifaVc1,
                ValorTarifaVc2 = contratoDto.ValorTarifaVc2,
                ValorTarifaVc3 = contratoDto.ValorTarifaVc3,
                VendedorId = contratoDto.VendedorId,
                //EquipamentoId = contratoDto.EquipamentoId == 0 ? null : contratoDto.EquipamentoId,
                DiaVencimento = contratoDto.DiaVencimento,
                DataContrato = (DateTime)contratoDto.DataContrato,
                ClienteId = contratoDto.ClienteId,
                CadenciaMovel = contratoDto.CadenciaMovel
            };
        }

        private void ContratoAtualizado(ContratoDTO contratoDto, Contrato contrato)
        {
            contrato.CadenciaFixa = contratoDto.CadenciaFixa;
            contrato.PrazoContratual = contratoDto.PrazoContratual;
            contrato.ValorConsumoMinimo = (decimal) contratoDto.ValorConsumoMinimo;
            contrato.ValorInstalacao = contratoDto.ValorInstalacao;
            contrato.ValorMensalidade = (decimal) contratoDto.ValorMensalidade;
            contrato.ValorTarifaLdn = contratoDto.ValorTarifaLdn;
            contrato.ValorTarifaLocal = contratoDto.ValorTarifaLocal;
            contrato.ValorTarifaVc1 = contratoDto.ValorTarifaVc1;
            contrato.ValorTarifaVc2 = contratoDto.ValorTarifaVc2;
            contrato.ValorTarifaVc3 = contratoDto.ValorTarifaVc3;
            contrato.VendedorId = contratoDto.VendedorId;
            //contrato.EquipamentoId = contratoDto.EquipamentoId == 0 ? null : contratoDto.EquipamentoId;
            contrato.DiaVencimento = contratoDto.DiaVencimento;
            contrato.DataContrato = (DateTime) contratoDto.DataContrato;
            contrato.ClienteId = contratoDto.ClienteId;
            contrato.CadenciaMovel = contratoDto.CadenciaMovel;
        }

        public ContratoDTO ContratoCliente(int clienteId)
        {
            var contrato = _contratoRepository.GetContratoCliente(clienteId);
            var contratoDto = Mapper.Map<ContratoDTO>(contrato);

            return contratoDto;
        }
    }
}
