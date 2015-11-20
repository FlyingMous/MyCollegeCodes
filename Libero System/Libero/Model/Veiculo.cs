using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero
{
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }

       
        public int AnoFab { get; set; }

        public virtual Modelo Modelo { get; set; }
        public virtual int ModeloId { get; set; }

        
        public string Placa { get; set; }

        
        public int Quilometragem { get; set; }
        public Gps Localizacao { get; set; }

        
        public string Cor { get; set; }

        
        public string TipoVeiculo { get; set; }
        
        public string Chassi { get; set; }

        public virtual List<Locacao> Locacoes { get; set; }


    }
}
