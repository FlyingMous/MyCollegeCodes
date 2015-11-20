using Libero.Interfaces;
using Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Repositorios
{
    public class RepoCliente : IRepoCliente, IDisposable
    {
        private IContext ctx = new Context();

        public RepoCliente(IContext ctx)
        {
            this.ctx = ctx;
        }
        public RepoCliente()
        {
            
        }

        public void CadastrarCliente(Cliente valor)
        {
            
                ctx.Clientes.Add(valor);
                ctx.SaveChanges();
            

        }
        public void ModificarCliente(Cliente valor)
        {
            
                ctx.Entry(valor).State = EntityState.Modified;
                ctx.SaveChanges();
            
        }
        public void ExcluirCliente(int? id)
        {
           
                var c = ctx.Clientes.Find(id);
                ctx.Clientes.Remove(c);
                ctx.SaveChanges();
            
        }
        public Cliente LerCliente(int? id)
        {
            
                var c = ctx.Clientes.Find(id);
                return c;
            
        }
        public List<Cliente> LerTodosCliente()
        {
            List<Cliente> listaCliente = new List<Cliente>();
           
                var c = ctx.Clientes.Where(x => x.ClienteId != null).Distinct();
                foreach (var item in c)
                {
                    listaCliente.Add(item);
                }
                return listaCliente;
            
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
