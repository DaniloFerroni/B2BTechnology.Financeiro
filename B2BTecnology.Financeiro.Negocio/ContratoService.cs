using System;
using System.Collections.Generic;
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

        public void Salvar(ContratoDTO contratoDto)
        {
            var clienteService = new ClienteService();
            clienteService.Salvar(contratoDto.Cliente);
            if (contratoDto.IdContrato == 0)
                Incluir(contratoDto);
            else
                Alterar(contratoDto);
        }

        public void Incluir(ContratoDTO contratoDto)
        {
            var contrato = ObjetoContrato(contratoDto);
            _contratoRepository.Incluir(contrato);
        }

        public ContratoDTO Pesquisar(int idContrato)
        {
            var contrato = _contratoRepository.GetContrato(idContrato);
            var contratoDto = Mapper.Map<ContratoDTO>(contrato);
            return contratoDto;
        }

        public List<ContratoDTO> Todos()
        {
            var contratos = _contratoRepository.GetAll();
            var contratosDto = Mapper.Map<List<ContratoDTO>>(contratos);
            return contratosDto;
        }

        public void Alterar(ContratoDTO contratoDto)
        {
            var contrato = _contratoRepository.GetContrato(contratoDto.IdContrato);
            ContratoAtualizado(contratoDto, contrato);

            _contratoRepository.Alterar(contrato);
        }

        private Contrato ObjetoContrato(ContratoDTO contratoDto)
        {
            return new Contrato
            {
                CadenciaFixa = contratoDto.CadenciaFixa,
                PrazoContratual = contratoDto.PrazoContratual,
                ValorConsumoMinimo = contratoDto.ValorConsumoMinimo ?? 0,
                ValorInstalacao = contratoDto.ValorInstalacao,
                ValorMensalidade = contratoDto.ValorMensalidade ?? 0,
                ValorTarifaLdn = contratoDto.ValorTarifaLdn,
                ValorTarifaLocal = contratoDto.ValorTarifaLocal,
                ValorTarifaVc1 = contratoDto.ValorTarifaVc1,
                ValorTarifaVc2 = contratoDto.ValorTarifaVc2,
                ValorTarifaVc3 = contratoDto.ValorTarifaVc3,
                VendedorId = contratoDto.VendedorId,
                //EquipamentoId = contratoDto.EquipamentoId == 0 ? null : contratoDto.EquipamentoId,
                DiaVencimento = contratoDto.DiaVencimento,
                DataContrato = contratoDto.DataContrato,
                ClienteId = contratoDto.ClienteId,
                CadenciaMovel = contratoDto.CadenciaMovel,
                //Did = contratoDto.Did,
                //AssinaturaDid = contratoDto.AssinaturaDid,
                //Valor0800 = contratoDto.Valor0800,
                //Assinatura0800 = contratoDto.Assinatura0800,
                //Valor0300 = contratoDto.Valor0300,
                //Assinatura0300 = contratoDto.Assinatura0300,
                //Valor4000 = contratoDto.Valor4000,
                //Assinatura4000 = contratoDto.Assinatura4000
            };
        }

        private void ContratoAtualizado(ContratoDTO contratoDto, Contrato contrato)
        {
            contrato.CadenciaFixa = contratoDto.CadenciaFixa;
            contrato.PrazoContratual = contratoDto.PrazoContratual;
            contrato.ValorConsumoMinimo = contratoDto.ValorConsumoMinimo ?? 0;
            contrato.ValorInstalacao = contratoDto.ValorInstalacao;
            contrato.ValorMensalidade = contratoDto.ValorMensalidade ?? 0;
            contrato.ValorTarifaLdn = contratoDto.ValorTarifaLdn;
            contrato.ValorTarifaLocal = contratoDto.ValorTarifaLocal;
            contrato.ValorTarifaVc1 = contratoDto.ValorTarifaVc1;
            contrato.ValorTarifaVc2 = contratoDto.ValorTarifaVc2;
            contrato.ValorTarifaVc3 = contratoDto.ValorTarifaVc3;
            contrato.VendedorId = contratoDto.VendedorId;
            //contrato.EquipamentoId = contratoDto.EquipamentoId == 0 ? null : contratoDto.EquipamentoId;
            contrato.DiaVencimento = contratoDto.DiaVencimento;
            contrato.DataContrato = contratoDto.DataContrato;
            contrato.ClienteId = contratoDto.ClienteId;
            contrato.CadenciaMovel = contratoDto.CadenciaMovel;
            contrato.PlanoId = contratoDto.PlanoId;

            //contrato.Did = contratoDto.Did;
            //contrato.AssinaturaDid = contratoDto.AssinaturaDid;
            //contrato.Valor0800 = contratoDto.Valor0800;
            //contrato.Assinatura0800 = contratoDto.Assinatura0800;
            //contrato.Valor0300 = contratoDto.Valor0300;
            //contrato.Assinatura0300 = contratoDto.Assinatura0300;
            //contrato.Valor4000 = contratoDto.Valor4000;
            //contrato.Assinatura4000 = contratoDto.Assinatura4000;
            
        }

        public ContratoDTO ContratoCliente(int clienteId)
        {
            var contrato = _contratoRepository.GetContratoCliente(clienteId);
            var contratoDto = Mapper.Map<ContratoDTO>(contrato);

            return contratoDto;
        }
    }
}
