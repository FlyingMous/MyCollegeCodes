using Libero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface ILocarDevolver
    {
        void LocarVeiculo(Veiculo veiculo, Cliente cliente);
        void DevolverVeiculo(Veiculo veiculo);
       
    }
}
