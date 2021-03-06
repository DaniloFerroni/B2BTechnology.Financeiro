﻿using System.Collections.Generic;
using System.Linq;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase.Repository
{
    public class ClienteRepository : BaseRepository<B2BSolution, Cliente>
    {
        public void Incluir(Cliente cliente)
        {
            DbSet.Add(cliente);
            Context.SaveChanges();
        }

        public void Alterar(Cliente cliente)
        {
            
            Context.SaveChanges();
        }

        public Cliente GetCliente(string documento)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Endereco")
                .Include("Contratos")
                .Include("Contratos.EquipamentoContrato")
                .Include("Contratos.EquipamentoContrato.Equipamentos")
                .Include("Contratos.ContratoAssinaturas")
                .FirstOrDefault(c => c.Documento == documento);
        }

        public Cliente GetClienteId(int clienteId)
        {
            LazyLoadingEnabled();
            return DbSet
                .Include("Contato")
                .Include("Contratos")
                .Include("Contratos.EquipamentoContrato")
                .Include("Contratos.EquipamentoContrato.Equipamentos")
                .First(c => c.IdCliente == clienteId);
        }


        public List<Cliente> GetAll()
        {
            LazyLoadingEnabled();
            return DbSet
                    .Include("Contratos")
                    .Include("Contratos.Vendedores")
                    .ToList();
        }
    }
}
