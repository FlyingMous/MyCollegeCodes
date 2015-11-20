using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero
{
    public class Fabricante
    {

        [Key]
        public int FabricanteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }
        public virtual List<Modelo> Modelos { get; set; }

        public virtual int ModeloId { get; set; }

       
    }
}
