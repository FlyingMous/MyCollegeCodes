using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero
{
    public class Modelo
    {
        [Key]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        
        public int FabricanteId { get; set; }
        public virtual Fabricante Fabricante { get; set; }

      
        public virtual List<Veiculo> Veiculos { get; set; }
        public virtual int VeiculoId { get; set; }
    }
}
