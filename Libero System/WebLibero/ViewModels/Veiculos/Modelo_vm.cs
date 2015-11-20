using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLibero.ViewModels.Veiculos
{
    public class Modelo_vm
    {
        [Key]
        public int ModeloId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }
        public SelectList Fabricantes { get; set; }
        public int FabricanteId { get; set; }
    }
}