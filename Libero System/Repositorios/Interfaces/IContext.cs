using Libero;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface IContext
    {
        IDbSet<Cliente> Clientes { get; set; }
        IDbSet<Veiculo> Veiculos { get; set; }
        IDbSet<Locacao> Locacoes { get; set; }
        IDbSet<Modelo> Modelos { get; set; }
        IDbSet<Fabricante> Fabricantes { get; set; }

        void SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
