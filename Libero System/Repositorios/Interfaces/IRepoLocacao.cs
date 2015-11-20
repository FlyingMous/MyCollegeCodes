using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libero;

namespace Libero.Interfaces
{
    public interface IRepoLocacao
    {
        void CadastrarLocacao(Veiculo veiculo, Cliente cliente);
        void RetornarLocacao(Veiculo veiculo);

    }
}
