using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class CursoService : ICursoService
    {

        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public Curso Cadastrar(Curso curso)
        {
            curso.ValidationResult = new CadastrarCursoValidator(_cursoRepository).Validate(curso);
            curso.Ativo = true;

            if (!curso.ValidationResult.IsValid)
                return curso;

            return _cursoRepository.Cadastrar(curso);
        }

        public Curso Atualizar(Curso curso)
        {
            curso.ValidationResult = new AtualizarCursoValidator(_cursoRepository).Validate(curso);
           
            if (!curso.ValidationResult.IsValid)
                return curso;

            curso.Ativo = true;

            return _cursoRepository.Atualizar(curso);
        }

        public bool Deletar(string Id)
        {
            var curso = _cursoRepository.ObterPorId(Id);
            if (curso == null)
                return false;

            curso.Ativo = false;
            _cursoRepository.Atualizar(curso);

            return true;
        }
    }
}
