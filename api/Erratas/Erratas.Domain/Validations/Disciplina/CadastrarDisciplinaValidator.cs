using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Disciplina
{
    public class CadastrarDisciplinaValidator : AbstractValidator<Entities.Disciplina>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly ICursoDisciplinaRepository _cursoDisciplinaRepository;
        public CadastrarDisciplinaValidator(IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository, ICursoDisciplinaRepository cursoDisciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
            _cursoDisciplinaRepository = cursoDisciplinaRepository;

            RuleFor(x => x.CursoDisciplinas).Must(SerCursosValidos).WithMessage("Curso(s) não é/são válido(s)");
            RuleFor(x => x.CursoDisciplinas.FirstOrDefault().CodigoModelo).Must(SerCodigoModeloValido).WithMessage("Código Modelo já existe");
            RuleFor(x => x.Id).Must(NaoExistir).WithMessage("Id já existe");
        }

        private bool SerCursosValidos(ICollection<CursoDisciplina> cursos)
        {
            foreach(var item in cursos)
            {
                if (_cursoRepository.ObterPorId(item.CursoId) == null)
                    return false;
            }
            return true;
        }
        private bool SerCodigoModeloValido(string CodigoModelo)
        {            
            return _cursoDisciplinaRepository.ObterPorModelo(CodigoModelo).Count() == 0;
        }
        private bool NaoExistir(string Id)
        {
            return _disciplinaRepository.ObterPorId(Id) == null;
        }
    }
}
