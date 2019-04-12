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
    public class AtualizarUsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public AtualizarUsuarioValidator(IDepartamentoRepository departamentoRepository, IUsuarioRepository usuarioRepository, ICargoRepository cargoRepository, ICursoRepository cursoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
            _cursoRepository = cursoRepository;
            _departamentoRepository = departamentoRepository;

            RuleFor(x => x.Id).Must(SerTrue).WithMessage("Id não existe");
            // RuleFor(x => x.Senha).Must(SerNull).WithMessage("Não é possivel enviar a senha para atualizar um usuário");
            RuleFor(x => x.CargoId).Must(SerValido).WithMessage("Cargo não é valido");
            RuleFor(x => x.UsuarioCursos).Must(SerCursoValido).WithMessage("Curso não é válido");
            RuleFor(x => x.DepartamentoId).Must(Existir).WithMessage("Departamento não é valido");
        }

        private bool SerTrue(Guid Id)
        {
            var retorno = _usuarioRepository.ObterPorId(Id);
            if (retorno != null)
                _usuarioRepository.Detach(retorno);

            return retorno  != null;
        }
        private bool Existir(Guid Id)
        {
            return _departamentoRepository.ObterPorId(Id) != null;
        }
        private bool SerNull(string Senha)
        {
            return string.IsNullOrEmpty(Senha);
        }

        private bool SerValido(Guid CargoId)
        {
            return _cargoRepository.ObterPorId(CargoId) != null;
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
