using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Interfaces
{
    public interface IRepoModelo
    {
        void CadastrarModelo(Modelo valor);
        void ModificarModelo(Modelo valor);
        void ExcluirModelo(int? id);
        Modelo LerModelo(int? id);
        List<Modelo> LerTodosModelo();

    }
}
