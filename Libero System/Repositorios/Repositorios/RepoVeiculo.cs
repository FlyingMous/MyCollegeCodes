using Libero.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Repositorios
{
    public class RepoVeiculo : IRepoVeiculo, IDisposable
    {
        private Context ctx = new Context();

        public RepoVeiculo(Context ctx)
        {
            this.ctx = ctx;
        }

        public RepoVeiculo()
        {
            
        }


        public void CadastrarVeiculo(Veiculo valor)
        {
            
                ctx.Veiculos.Add(valor);
                ctx.SaveChanges();
            
        }

        public Veiculo LerVeiculo(int? id)
        {
            
                var veic = ctx.Veiculos.Find(id);
                return veic;
            
        }

        public void ExcluirVeiculo(int? id)
        {
            
                var veic = ctx.Veiculos.Find(id);
                ctx.Veiculos.Remove(veic);
                ctx.SaveChanges();
            
        }

        public void ModificarVeiculo(Veiculo valor)
        {
            
                ctx.Entry(valor).State = EntityState.Modified;
                ctx.SaveChanges();
            
        }
        public List<Veiculo> LerTodosVeiculo()
        {
            List<Veiculo> listaVeic = new List<Veiculo>();
            
                var veic = ctx.Veiculos.Where(x => x.VeiculoId != null).Distinct();
                foreach (var item in veic)
                {
                    listaVeic.Add(item);
                }
                return listaVeic;
            
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
