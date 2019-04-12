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
    public class CadastrarUsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public CadastrarUsuarioValidator(IDepartamentoRepository departamentoRepository, IUsuarioRepository usuarioRepository, ICargoRepository cargoRepository, ICursoRepository cursoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
            _cursoRepository = cursoRepository;
            _departamentoRepository = departamentoRepository;

            RuleFor(x => x.Email).Must(TerEmailValido).WithMessage("E-mail não é único");            
            RuleFor(x => x.CargoId).Must(TerCargoValido).WithMessage("Cargo não é válido");
            RuleFor(x => x.UsuarioCursos).Must(SerCursoValido).WithMessage("Curso não é válido");
            RuleFor(x => x.DepartamentoId).Must(Existir).WithMessage("Departamento não é valido");

        }
        private bool TerEmailValido(string Email)
        {
            return _usuarioRepository.ObterPorEmail(Email) == null;
        }
        private bool Existir(Guid Id)
        {
            return _departamentoRepository.ObterPorId(Id) != null;
        }
        private bool TerCargoValido(Guid CargoId)
        {
            return _cargoRepository.CargoExiste(CargoId) != null;
        }

        private bool SerCursoValido(ICollection<UsuarioCurso> UsuarioCursos)
        {
            foreach (var item in UsuarioCursos)
            {
                if (_cursoRepository.ObterPorId(item.CursoId) == null)
                    return false;
            }

            return true;
        }
    }
}
