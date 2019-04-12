using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.CargoPermissao
{
    public class AtualizarCargoPermissaoModuloValidator : AbstractValidator<CargoPermissaoModulo>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IModuloRepository _moduloRepository;
        public AtualizarCargoPermissaoModuloValidator(
            ICargoRepository cargoRepository,
            IModuloRepository moduloRepository)
        {
            _cargoRepository = cargoRepository;
            _moduloRepository = moduloRepository;

            RuleFor(x => x.CargoId).Must(BeAValidCargo).WithMessage("Cargo não é válido");
            RuleFor(x => x.ModuloId).Must(BeAValidModulo).WithMessage("Módulo não é válido");
        }
        private bool BeAValidCargo(Guid CargoId)
        {
            return _cargoRepository.ObterPorId(CargoId) != null;
        }
        private bool BeAValidModulo(Guid ModuloId)
        {
            return _moduloRepository.ObterPorId(ModuloId) != null;
        }
    }
}
