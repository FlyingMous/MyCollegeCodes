using Libero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Repositorios
{
    public class RepoLocacao : IRepoLocacao, IDisposable
    {
        private Context ctx = new Context();

        public RepoLocacao(Context ctx)
        {
            this.ctx = ctx;
        }

        public RepoLocacao()
        {
            
        }
        public void CadastrarLocacao(Veiculo veiculo, Cliente cliente)
        {
           
                var veicLocado = ctx.Veiculos.Find(veiculo.VeiculoId);
                var clienteLocatario = ctx.Clientes.Find(cliente.ClienteId);

                var loc = ctx.Locacoes;

                Locacao l = new Locacao();

                l.Cliente = clienteLocatario;
                l.Veiculo = veicLocado;
                l.DataSaida = DateTime.Now;
                ctx.SaveChanges();
            
        }

        public void RetornarLocacao(Veiculo veiculo)
        {
            
                var veic = ctx.Locacoes.Where(y => y.DataRetorno == null).FirstOrDefault(x => x.Veiculo.VeiculoId == veiculo.VeiculoId);

                veic.DataRetorno = DateTime.Now;

                ctx.SaveChanges();
            
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
