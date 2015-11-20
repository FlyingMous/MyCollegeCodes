using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLibero.ViewModels.Clientes
{
    public class MostrarClientes_vm
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Endereco { get; set; }
    }
}