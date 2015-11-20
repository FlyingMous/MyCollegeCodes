using Libero.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Repositorios
{
    public class RepoFabricante : IRepoFabricante, IDisposable
    {

        private Context ctx = new Context();

        public RepoFabricante(Context ctx)
        {
            this.ctx = ctx;
        }

        public RepoFabricante()
        {
            
        }


        public void CadastrarFabricante(Fabricante valor)
        {
           
                ctx.Fabricantes.Add(valor);
                ctx.SaveChanges();
            
        }

        public void ModificarFabricante(Fabricante valor)
        {
            
                ctx.Entry(valor).State = EntityState.Modified;
                ctx.SaveChanges();
            
        }

        public void ExcluirFabricante(int? id)
        {
            
                var fab = ctx.Fabricantes.Find(id);
                ctx.Fabricantes.Remove(fab);
                ctx.SaveChanges();
            
        }

        public Fabricante LerFabricante(int? id)
        {
            
                var fab = ctx.Fabricantes.Find(id);
                return fab;
            
        }

        public List<Fabricante> LerTodosFabricante()
        {
            List<Fabricante> listaFab = new List<Fabricante>();
            
                var fab = ctx.Fabricantes.Where(x => x.FabricanteId != null).Distinct();
                foreach (var item in fab)
                {
                    listaFab.Add(item);
                }
                return listaFab;
            
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
