using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Usuarios
{
    public class TrocarSenha
    {
        [Required(ErrorMessage = "Senha é obrigatório")]
        [SameValueT]
        public string Senha { get; set; }

        [Required(ErrorMessage = "ConfirmaSenha é obrigatório")]
        public string ConfirmaSenha { get; set; }
    }
    public class SameValueTAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (TrocarSenha)validationContext.ObjectInstance;

            if (model.ConfirmaSenha != model.Senha)
                return new ValidationResult("Senha e confirmaSenha são diferentes");

            return ValidationResult.Success;
        }
    }
}
