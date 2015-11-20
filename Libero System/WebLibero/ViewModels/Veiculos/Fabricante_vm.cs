using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLibero.ViewModels.Veiculos
{
    public class Fabricante_vm
    {
        
        [Key]
        public int FabricanteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }
    }
}