using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLibero.ViewModels.Locacoes
{
    public class RetornaLocacao_vm
    {
        [Key]
        public int LocacaoId { get; set; }

        public SelectList Cliente { get; set; }

        public SelectList Veiculo { get; set; }

        [Required(ErrorMessage="Campo Obrigatorio")]
        public DateTime DataRetorno { get; set; }
    }
}