using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2BTecnology.Financeiro.DataBase.Map;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase
{
    public class B2BTecnologyDataBase : DbContext
    {
        static B2BTecnologyDataBase()
        {
            Database.SetInitializer<B2BTecnologyDataBase>(null);
        }

        public B2BTecnologyDataBase()
            : base("Name=B2BTecnologyDataBase")
        {
            
        }

        public IDbSet<Contato> Contatos { get; set; }
        public IDbSet<Endereco> Enderecos { get; set; }
        public IDbSet<Equipamentos> Equipamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EquipamentoMap());
        }
    }
}
