using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erratas.Domain.Entities;

namespace Erratas.Domain.Validations
{
    public class AtualizarCargoPermissaoValidator : AbstractValidator<Erratas.Domain.Entities.CargoPermissao>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly ICargoRepository _cargoRepository;
        public AtualizarCargoPermissaoValidator(
            IPermissaoRepository permissaoRepository, 
            ICargoRepository cargoRepository)
        {
            _permissaoRepository = permissaoRepository;
            _cargoRepository = cargoRepository;

            RuleFor(x => x.CargoId).Must(BeAValidCargo).WithMessage("Cargo não é válido");
            RuleFor(x => x.PermissaoId).Must(BeAValidPermissao).WithMessage("Permissao não é válida");
        }
        private bool BeAValidCargo(Guid CargoId)
        {
            return _cargoRepository.ObterPorId(CargoId) != null;
        }

        private bool BeAValidPermissao(Guid PermissaoId)
        {
            return _permissaoRepository.ObterPorId(PermissaoId) != null;
        }
    }
}
