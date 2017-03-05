using System;
using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ContratoAssinaturaRepository : BaseRepository<B2BSolution, ContratoAssinaturas>
    {
        public void Salvar(List<ContratoAssinaturas> contratoAssinaturas, int contrato)
        {
            var assinaturas = DbSet.Where(c => c.IdContrato == contrato);
            if (assinaturas.Any())
                DbSet.RemoveRange(assinaturas);

            if (contratoAssinaturas.Any())
                DbSet.AddRange(contratoAssinaturas);

            Context.SaveChanges();
        }
    }
}
