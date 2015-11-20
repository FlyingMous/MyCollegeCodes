using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libero
{
    public class Locacao
    {
        [Key]
        public int LocacaoId { get; set; }

        
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        
        public virtual Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }

        
        public Nullable<DateTime> DataSaida { get; set; }
        public Nullable<DateTime> DataRetorno { get; set; }

    }
}
