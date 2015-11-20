using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero.Interfaces
{
    public interface IRepoCliente
    {
        void CadastrarCliente(Cliente valor);
        void ModificarCliente(Cliente valor);
        void ExcluirCliente(int? id);
        Cliente LerCliente(int? id);
        List<Cliente> LerTodosCliente();
    }
}
