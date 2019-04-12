using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Curso
{
    public class CadastrarCursoValidator : AbstractValidator<Entities.Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public CadastrarCursoValidator(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            RuleFor(x => x.Id).Must(NaoExistir).WithMessage("Id já existe.");
        }

        private bool NaoExistir(string Id)
        {
            return _cursoRepository.ObterPorId(Id) == null;
        }
    }
}
