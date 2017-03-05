
using System.Data.Entity;
using B2BTecnology.Financeiro.DataBase.Map;
using B2BTecnology.Financeiro.Entidades;

namespace B2BTecnology.Financeiro.DataBase
{
    public class B2BSolution : DbContext
    {
        static B2BSolution()
        {
            Database.SetInitializer<B2BSolution>(null);
        }

        public B2BSolution()
            : base("Name=B2BSolution")
        {
            Database.SetInitializer<B2BSolution>(null);
            //Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<Contato> Contatos { get; set; }
        public IDbSet<Endereco> Enderecos { get; set; }
        public IDbSet<Equipamentos> Equipamentos { get; set; }
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<Vendedores> Vendedores { get; set; }
        public IDbSet<Contrato> Contratos { get; set; }
        public IDbSet<Pagamento> Pagamentos { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<EquipamentoContrato> EquipamentoContratos { get; set; }
        public IDbSet<ContratoAssinaturas> ContratoAssinaturas { get; set; }
        public IDbSet<Documento> Documento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new VendedoresMap());
            modelBuilder.Configurations.Add(new ContratoMap());
            modelBuilder.Configurations.Add(new PagamentoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EquipamentoMap());
            modelBuilder.Configurations.Add(new EquipamentoContratoMap());
        }
    }
}
