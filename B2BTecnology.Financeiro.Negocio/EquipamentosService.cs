using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using B2BTecnology.Financeiro.DataBase.Repository;
using B2BTecnology.Financeiro.DTO;
using B2BTecnology.Financeiro.Entidades;
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

        public void Salvar(List<EquipamentosDTO> equipamentosAlterados)
        {
            var incluidos = equipamentosAlterados.Where(e => e.IdEquipamento == 0).ToList();

            var equipamentos = _equipamentosRepository.GetAll();
            equipamentosAlterados = equipamentosAlterados.Where(e => e.IdEquipamento != 0).ToList();

            var excluidos = equipamentos.Where(atual => !equipamentosAlterados.Exists(e => e.IdEquipamento == atual.IdEquipamento))
                            .ToList();

            Incluir(incluidos);
            Excluir(excluidos);
        }

        private void Incluir(List<EquipamentosDTO> equipamentos)
        {
            var incluidos = equipamentos.Select(e => new Equipamentos
            {
                IdEquipamento = e.IdEquipamento,
                Marca = e.Marca,
                Modelo = e.Modelo,
                NumeroSerie = e.NumeroSerie,
                NumeroSerieB2b = e.NumeroSerieB2b,
            }).ToList();

            _equipamentosRepository.Inserir(incluidos);
        }

        private void Excluir(List<Equipamentos> equipamentos)
        {
            _equipamentosRepository.Excluir(equipamentos);
        }
    }
}
