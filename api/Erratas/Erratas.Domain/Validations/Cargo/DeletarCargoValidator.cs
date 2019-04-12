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
    public class DeletarCargoValidator : AbstractValidator<Entities.Cargo>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;
        public DeletarCargoValidator(IUsuarioRepository usuarioRepository, ICargoRepository cargoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
            RuleFor(x => x.Id).Must(HasNoReference).WithMessage("Cargo possui um ou mais usuários vinculados");
            RuleFor(x => x.Id).Must(Exist).WithMessage("Id não é válido");      
        }
        private bool HasNoReference(Guid Id)
        {
            return _usuarioRepository.ObterUsuariosPorCargo(Id).Count() == 0;
        }

        private bool Exist(Guid Id)
        {
            return _cargoRepository.ObterPorId(Id) != null;
        }
    }
}
