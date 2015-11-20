using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libero;

namespace Libero.Interfaces
{
    public interface IRepoVeiculo
    {
        void CadastrarVeiculo(Veiculo valor);
        void ModificarVeiculo(Veiculo valor);
        void ExcluirVeiculo(int? id);
        Veiculo LerVeiculo(int? id);
        List<Veiculo> LerTodosVeiculo();
    }
}
