using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Cargo
{
    public class AtualizarCargoValidator : AbstractValidator<Entities.Cargo>
    {
         private readonly ICargoRepository _cargoRepository;
         public AtualizarCargoValidator(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
            RuleFor(x => x.Id).Must(Existir).WithMessage("Id não existe.");
        }
        private bool Existir(Guid Id)
        {
            var retorno = _cargoRepository.ObterPorId(Id);
            if (retorno != null)
                _cargoRepository.Detach(retorno);

            return retorno != null;
        }
    }
}
