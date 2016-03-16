using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository
    {
        private readonly B2BSolution _context = new B2BSolution();

        public Contrato GetCliente(int idCliente)
        {
            return _context.Contratos.FirstOrDefault(c => c.IdContrato == idCliente);
        }

        public List<Pagamento> GetAll()
        {
            return _context.Pagamentos.ToList();
        }

        public List<Contato> GetAllContato()
        {
            return _context.Contatos.ToList();
        }
    }
}
