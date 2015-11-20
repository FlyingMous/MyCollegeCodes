using Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Libero
{
    public class Context : DbContext, IContext
    {
        private Context con { get; set; }
        public Context(Context c)
        {
            this.con = c;
        }
        public Context() { }
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<Veiculo> Veiculos { get; set; }
        public IDbSet<Locacao> Locacoes { get; set; }
        public IDbSet<Modelo> Modelos { get; set; }
        public IDbSet<Fabricante> Fabricantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");
            modelBuilder.Entity<Locacao>().ToTable("Locacao");
            modelBuilder.Entity<Modelo>().ToTable("Modelo");
            modelBuilder.Entity<Fabricante>().ToTable("Fabricante");
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        

    }
}
