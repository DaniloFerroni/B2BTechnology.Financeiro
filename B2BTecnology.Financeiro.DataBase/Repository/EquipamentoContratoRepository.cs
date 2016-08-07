using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class EquipamentoContratoRepository : BaseRepository<B2BSolution, EquipamentoContrato>
    {
        public void Inserir(List<EquipamentoContrato> equipamentosContrato)
        {
            equipamentosContrato.ForEach(e => DbSet.Add(e));
            Context.SaveChanges();
        }

        public void Deletar(List<EquipamentoContrato> equipamentosContrato)
        {
            equipamentosContrato.ForEach(e =>
            {
                var entity = DbSet.First(d => d.EquipamentoContratoId == e.EquipamentoContratoId);
                DbSet.Remove(entity);
            });
            Context.SaveChanges();
        }

    }
}
