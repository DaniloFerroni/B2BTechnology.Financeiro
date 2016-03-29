using System.Collections.Generic;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Negocio.Map;

namespace B2BTecnology.Financeiro.Negocio
{
    public class EquipamentosService : Mapeamento
    {
        private readonly EquipamentosRepository _equipamentosRepository = new EquipamentosRepository();

        public List<EquipamentosDTO> Todos()
        {
            var equipamentos = _equipamentosRepository.GetAll();

            var equipamentosDto = Mapper.Map<List<EquipamentosDTO>>(equipamentos);

            return equipamentosDto;
        }
    }
}
