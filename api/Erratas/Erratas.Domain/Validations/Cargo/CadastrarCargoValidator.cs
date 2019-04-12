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
    public class CadastrarCargoValidator : AbstractValidator<Entities.Cargo>
    {
        private readonly ICargoRepository _cargoRepository;
        public CadastrarCargoValidator(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
            RuleFor(x => x.Nome).Must(BeUniqueName).WithMessage("Nome não é único");      
        }
        private bool BeUniqueName(string Nome)
        {
            return _cargoRepository.NomeExiste(Nome) == null;
        }
    }
}
