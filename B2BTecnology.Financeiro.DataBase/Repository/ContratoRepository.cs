using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContratoRepository : BaseRepository<B2BSolution, Contrato>
    {
        public void Incluir(Contrato contrato)
        {
            DbSet.Add(contrato);

            Context.SaveChanges();
        }

        public void Alterar(Contrato contrato)
        {
            Context.SaveChanges();
        }

        public Contrato GetContrato(int idContrato)
        {
            LazyLoadingEnabled();
            return DbSet.First(c => c.IdContrato == idContrato);
        }
    }
}
