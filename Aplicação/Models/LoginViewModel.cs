using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicação.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class registerViewModel
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Display(Name = "cidade")]
        [Required(ErrorMessage = "Informe a cidade")]
        public string cidade { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Informe o Sexo")]
        public string sexo { get; set; }
        [Display(Name = "nome")]
        [Required(ErrorMessage = "Informe Seu nome")]
        public string nome { get; set; }
        [Display(Name = "telefone")]
        [Required(ErrorMessage = "Informe o Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string telefone { get; set; }
        [Display(Name = "cpf")]
        [Required(ErrorMessage = "Informe Seu CPF")]
     
        public string cpf { get; set; }


        [Required(ErrorMessage = "Informe o email")]
        [EmailAddress]
        public string Email { get; set; }
    }
    }