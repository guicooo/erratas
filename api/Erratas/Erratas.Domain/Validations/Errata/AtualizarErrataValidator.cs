using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Validations.Errata
{
    public class AtualizarErrataValidator : AbstractValidator<Entities.Errata>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IInstitutoRepository _institutoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IErrataRepository _errataRepository;
        private readonly IMotivoErrataRepository _motivoErrataRepository;
        private readonly IUnidadeRepository _unidadeRepository;  
        public AtualizarErrataValidator(IUsuarioRepository usuarioRepository,
            IInstitutoRepository institutoRepository,
            IDisciplinaRepository disciplinaRepository,
            ICursoRepository cursoRepository,
            IErrataRepository errataRepository,
            IMotivoErrataRepository motivoErrataRepository,
            IUnidadeRepository unidadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _institutoRepository = institutoRepository;
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
            _errataRepository = errataRepository;
            _motivoErrataRepository = motivoErrataRepository;
            _unidadeRepository = unidadeRepository;


            RuleFor(x => x.Id).Must(Existir).WithMessage("Id não é válido");
            RuleFor(x => x.ResponsavelInsercaoId).Must(SerUsuarioValido).WithMessage("Responsavel Inserção não é válido");
            RuleFor(x => x.ResponsavelRevisaoId).Must(SerUsuarioValido).WithMessage("Responsavel Revisão não é válido");
            RuleFor(x => x.InstitutoId).Must(SerInstitutoValido).WithMessage("Instituto não é válido");
            RuleFor(x => x.DisciplinaId).Must(SerDisciplinaValida).WithMessage("Disciplina não é válida");
            RuleFor(x => x.ErrataCursos).Must(SerCursosValidos).WithMessage("Curso(s) não é(são) válido(s)");
            RuleFor(x => x.MotivoErrataId).Must(SerMotivoErrataValido).WithMessage("Motivo não é válido");
            RuleFor(x => x.UnidadeId).Must(SerUnidadeValida).WithMessage("Unidade não é válida");
        }
        private bool Existir(Guid Id)
        {
            return _errataRepository.ObterPorId(Id) != null;
        }
        private bool SerUsuarioValido(Guid UsuarioId)
        {
            return _usuarioRepository.ObterPorId(UsuarioId) != null;
        }

        private bool SerInstitutoValido(Guid InstitutoId)
        {
            return _institutoRepository.ObterPorId(InstitutoId) != null;
        }
        private bool SerMotivoErrataValido(Guid MotivoErrataId)
        {
            return _motivoErrataRepository.ObterPorId(MotivoErrataId) != null;
        }

        private bool SerUnidadeValida(Guid UnidadeId)
        {
            return _unidadeRepository.ObterPorId(UnidadeId) != null;
        }
        private bool SerDisciplinaValida(string DisciplinaId)
        {
            return _disciplinaRepository.ObterPorId(DisciplinaId) != null;
        }

        private bool SerCursosValidos(ICollection<ErrataCurso> cursos)
        {
            if (cursos == null)
                return true;

            foreach (var item in cursos)
            {
                if (_cursoRepository.ObterPorId(item.CursoId) == null)
                    return false;
            }

            return true;
        }
    }
}
