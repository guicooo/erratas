using AutoMapper;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Cursos;
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
    public class CursoAppService : ICursoAppService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly ICursoService _cursoService;
        private readonly IUnitOfWork _uow;
        public CursoAppService(ICursoRepository cursoRepository, ICursoService cursoService, IUnitOfWork uow)
        {
            _cursoRepository = cursoRepository;
            _cursoService = cursoService;
            _uow = uow;
        }
        public IEnumerable<Curso> Listar()
        {
            return _cursoRepository.Listar();
        }
        public Curso Cadastrar(CursoModel cursoModel)
        {
            var curso = Mapper.Map<CursoModel, Curso>(cursoModel);
            _uow.BeginTransaction();

            curso = _cursoService.Cadastrar(curso);
            if (curso.ValidationResult.IsValid)
                _uow.Commit();

            return curso;       
        }
        public Curso Atualizar(string Id, AtualizarCursoModel cursoModel)
        {
            var curso = Mapper.Map<AtualizarCursoModel, Curso>(cursoModel);
            curso.Id = Id;
            _uow.BeginTransaction();

            curso = _cursoService.Atualizar(curso);
            if (curso.ValidationResult.IsValid)
                _uow.Commit();

            return curso;
        }
        public bool Deletar(string Id)
        {
            _uow.BeginTransaction();
            var retorno = _cursoService.Deletar(Id);
            if (retorno)
                _uow.Commit();

            return retorno;
        }


        public Curso Obter(string Id)
        {
            return _cursoRepository.ObterPorId(Id);
        }
    }
}
