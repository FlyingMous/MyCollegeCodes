using Libero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libero.Repositorios;
using Repositorios.Interfaces;

namespace Repositorios.Servico
{
   
    public class LocarDevolver: ILocarDevolver
    {

        public static RepoLocacao repo = new RepoLocacao();

        public void LocarVeiculo(Veiculo veiculo, Cliente cliente)
        {

            repo.CadastrarLocacao(veiculo, cliente);

           
        }
        public void DevolverVeiculo(Veiculo veiculo)
        {

            repo.RetornarLocacao(veiculo);
           
        }
    }
}
