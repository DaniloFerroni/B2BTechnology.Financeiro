using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class EquipamentosRepository : BaseRepository<B2BSolution, Equipamentos>
    {
        public List<Equipamentos> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet.ToList();
        }
    }
}
