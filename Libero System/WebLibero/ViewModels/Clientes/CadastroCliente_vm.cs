﻿using Libero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLibero.ViewModels.Clientes
{
    public class CadastroCliente_vm
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        private string cpf;

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                if (Validacoes.CpfValido(value))
                    this.cpf = value;
                else
                    this.cpf = null;
            }
        }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string DadosCartao { get; set; }
    }
}