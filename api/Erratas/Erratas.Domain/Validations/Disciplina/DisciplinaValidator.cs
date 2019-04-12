using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Disciplina
{
    public class DisciplinaValidator : AbstractValidator<Entities.Disciplina>
    {
        public DisciplinaValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id é obrigatório");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");            
            RuleFor(x => x.CursoDisciplinas).NotEmpty().WithMessage("Ao menos um Curso deve ser vinculado");
        }
    }
}
