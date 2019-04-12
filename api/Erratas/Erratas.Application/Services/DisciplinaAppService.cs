using AutoMapper;
using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Disciplinas;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class DisciplinaAppService : IDisciplinaAppService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IDisciplinaService _disciplinaService;
        private readonly IUnitOfWork _uow;
        public DisciplinaAppService(IDisciplinaRepository disciplinaRepository, IDisciplinaService disciplinaService, IUnitOfWork uow)
        {
            _disciplinaRepository = disciplinaRepository;
            _disciplinaService = disciplinaService;
            _uow = uow;
        }
        public IEnumerable<Disciplina> Listar()
        {
            return _disciplinaRepository.Listar();
        }
        public Disciplina Cadastrar(DisciplinaModel disciplinaModel)
        {
            var disciplina = Mapper.Map<DisciplinaModel, Disciplina>(disciplinaModel);
            foreach(var item in disciplinaModel.Cursos)
            {
                disciplina.CursoDisciplinas.Add(new CursoDisciplina() { Id = Guid.NewGuid(), CodigoModelo = disciplinaModel.CodigoModelo, CursoId = item, DisciplinaId = disciplina.Id });
            }

            _uow.BeginTransaction();

            disciplina = _disciplinaService.Cadastrar(disciplina);

            if (disciplina.ValidationResult.IsValid)
                _uow.Commit();

            return disciplina;
        }
        public Disciplina Atualizar(string Id, AtualizarDisciplinaModel atualizarDisciplinaModel)
        {
            var disciplina = Mapper.Map<AtualizarDisciplinaModel, Disciplina>(atualizarDisciplinaModel);
            disciplina.Id = Id;
            foreach (var item in atualizarDisciplinaModel.Cursos)
            {
                disciplina.CursoDisciplinas.Add(new CursoDisciplina() { Id = Guid.NewGuid(), CodigoModelo = atualizarDisciplinaModel.CodigoModelo, CursoId = item, DisciplinaId = disciplina.Id });
            }

            _uow.BeginTransaction();

            disciplina = _disciplinaService.Atualizar(disciplina);

            if (disciplina.ValidationResult.IsValid)
                _uow.Commit();

            return disciplina;
        }
        public ObterDisciplinaModel Obter(string Id)
        {
            var disciplina = _disciplinaRepository.ObterPorId(Id);
            return new DisciplinaAdapter().DisciplinaParaObterDisciplinaModel(disciplina);
        }
        public bool Deletar(string Id)
        {
            _uow.BeginTransaction();
            var retorno = _disciplinaService.Deletar(Id);
            if (retorno)
                _uow.Commit();

            return retorno;
        }
    }
}
