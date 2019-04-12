using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoDisciplinaRepository _cursoDisciplinaRepository;
        private readonly ICursoRepository _cursoRepository;
        public DisciplinaService(IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository, ICursoDisciplinaRepository cursoDisciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
            _cursoDisciplinaRepository = cursoDisciplinaRepository;
        }
        public Disciplina Cadastrar(Disciplina disciplina)
        {
            if (!disciplina.EhValido())
                return disciplina;

            disciplina.ValidationResult = new CadastrarDisciplinaValidator(_disciplinaRepository, _cursoRepository, _cursoDisciplinaRepository).Validate(disciplina);
            disciplina.Ativo = true;

            if (!disciplina.ValidationResult.IsValid)
                return disciplina;

            return _disciplinaRepository.Cadastrar(disciplina);
        }


        public Disciplina Atualizar(Disciplina disciplina)
        {
            if (!disciplina.EhValido())
                return disciplina;

            disciplina.ValidationResult = new AtualizarDisciplinaValidator(_disciplinaRepository, _cursoRepository, _cursoDisciplinaRepository).Validate(disciplina);

            var aux = _disciplinaRepository.ObterPorId(disciplina.Id);
            var cursosDisciplinas = aux.CursoDisciplinas.Select(x => x.Id).ToList();
            _disciplinaRepository.Detach(aux);

            if (!disciplina.ValidationResult.IsValid)
                return disciplina;

            // Deleta os cursos antigos, para cadastrar os novos
            foreach (var item in cursosDisciplinas)
                _cursoDisciplinaRepository.Deletar(item);
                                
            // Cadastra  os novos
            foreach (var item in disciplina.CursoDisciplinas)
                _cursoDisciplinaRepository.Cadastrar(item);

            disciplina.Ativo = true;

            return _disciplinaRepository.Atualizar(disciplina);
        }
        public bool Deletar(string Id)
        {
            var disciplina = _disciplinaRepository.ObterPorId(Id);
            if (disciplina == null)
                return false;

            disciplina.Ativo = false;
            _disciplinaRepository.Atualizar(disciplina);

            return true;
        }
    }
}
