using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
       
        public UsuarioValidator()
        {                    
            RuleFor(x => x.Senha).Must(BeAValidPassword).WithMessage("Senha não é válida");
        }     
        private bool BeAValidPassword(string Senha)
        {
            if (string.IsNullOrEmpty(Senha))
                return true;

            return Regex.IsMatch(Senha, @"^[0-9a-fA-F]{32}$", RegexOptions.Compiled);
        }        
    }
}
