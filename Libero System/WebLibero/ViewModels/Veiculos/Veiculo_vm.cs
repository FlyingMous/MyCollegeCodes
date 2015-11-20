using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLibero.ViewModels.Veiculos
{
    public class Veiculo_vm
    {
        [Key]
        public int VeiculoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Placa { get; set; }
    }
}