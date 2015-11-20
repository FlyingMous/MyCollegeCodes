using Libero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLibero.ViewModels.Veiculos
{
    public class CadastroVeiculo_vm
    {
        [Key]
        public int VeiculoId { get; set; }

        
        public int AnoFab { get; set; }

        
        public string Placa { get; set; }

        
        public int Quilometragem { get; set; }

        
        public string Cor { get; set; }

        
        public string TipoVeiculo { get; set; }

        
        public string Chassi { get; set; }

        
        public SelectList Modelos { get; set; }
        public int ModeloId { get; set; }

    }
}