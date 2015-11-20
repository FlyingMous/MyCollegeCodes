using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Interfaces
{
    public interface IRepoFabricante
    {
        void CadastrarFabricante(Fabricante valor);
        void ModificarFabricante(Fabricante valor);
        void ExcluirFabricante(int? id);
        Fabricante LerFabricante(int? id);
        List<Fabricante> LerTodosFabricante();
    }
}
