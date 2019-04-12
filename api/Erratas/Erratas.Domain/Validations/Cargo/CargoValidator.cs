using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations
{
    public class CargoValidator : AbstractValidator<Entities.Cargo>
    {        
        public CargoValidator()
        {            
            RuleFor(x => x.Nome).Must(BeStrong).WithMessage("Nome não tem mais de 3 caracteres");      
        }
        private bool BeStrong(string Nome)
        {
            return Nome.Length >= 3;
        }
    }
}
