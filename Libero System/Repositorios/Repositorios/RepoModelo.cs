using Libero.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Repositorios
{
    public class RepoModelo : IRepoModelo, IDisposable
    {
        private Context ctx = new Context();

        public RepoModelo(Context ctx)
        {
            this.ctx = ctx;
        }

        public RepoModelo()
        {

        }


        public void CadastrarModelo(Modelo valor)
        {

            ctx.Modelos.Add(valor);
            ctx.SaveChanges();

        }

        public Modelo LerModelo(int? id)
        {

            var modelo = ctx.Modelos.Find(id);
            return modelo;

        }

        public List<Modelo> LerTodosModelo()
        {
            List<Modelo> listaModelos = new List<Modelo>();


            var modelos = ctx.Modelos.Distinct().Where(x => x.ModeloId != null);
            foreach (var item in modelos)
            {
                listaModelos.Add(item);
            }

            return listaModelos;

        }
        public void ExcluirModelo(int? id)
        {

            var mod = ctx.Modelos.Find(id);
            ctx.Modelos.Remove(mod);
            ctx.SaveChanges();

        }

        public void ModificarModelo(Modelo valor)
        {

            ctx.Entry(valor).State = EntityState.Modified;
            ctx.SaveChanges();

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
