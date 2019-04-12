using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models
{
    
    public class CadastrarSenhaModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Senha é obrigatório")]
        [SameValue]
        public string Senha { get; set; }

        [Required(ErrorMessage = "ConfirmaSenha é obrigatório")]
        public string ConfirmaSenha { get; set; }
    }

    public class SameValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CadastrarSenhaModel)validationContext.ObjectInstance;
           
            if (model.ConfirmaSenha != model.Senha)           
                return new ValidationResult("Senha e confirmaSenha são diferentes");
           
             return ValidationResult.Success;            
        }
    }
}
