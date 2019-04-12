using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Curso
{
    public class AtualizarCursoValidator : AbstractValidator<Entities.Curso>
    {
        private readonly ICursoRepository _cursoRepository;
        public AtualizarCursoValidator(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            RuleFor(x => x.Id).Must(Existir).WithMessage("Id não existe.");
        }
        private bool Existir(string Id)
        {
            var retorno = _cursoRepository.ObterPorId(Id);
            if (retorno != null)
                _cursoRepository.Detach(retorno);

            return retorno != null;
        }
    }
}
