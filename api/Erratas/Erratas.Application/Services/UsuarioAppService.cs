using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Interfaces;
using Erratas.Application.Adapters;
using Erratas.Application.Models.Usuarios;
using System.Security.Claims;
using System.Web;

namespace Erratas.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _uow;
        public UsuarioAppService(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository, IUnitOfWork uow)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _uow = uow;
        }

        public Usuario Cadastrar(UsuarioModel usuarioModel)
        {                      
            var usuario = Mapper.Map<UsuarioModel, Usuario>(usuarioModel);
            usuario.Id = Guid.NewGuid();
            
            foreach(var item in usuarioModel.Cursos)
            {
                usuario.UsuarioCursos.Add(new UsuarioCurso() { Id = Guid.NewGuid(), CursoId = item, UsuarioId = usuario.Id });
            }

            _uow.BeginTransaction();

            usuario = _usuarioService.Cadastrar(usuario);
            if (usuario.ValidationResult.IsValid)
                _uow.Commit();

            return usuario;
        }

        public Usuario Atualizar(Guid Id, UsuarioAtualizarModel usuarioModel)
        {
            var usuario = Mapper.Map<UsuarioAtualizarModel, Usuario>(usuarioModel);
            usuario.Id = Id;
          

            foreach (var item in usuarioModel.Cursos)
            {
                usuario.UsuarioCursos.Add(new UsuarioCurso() { Id = Guid.NewGuid(), CursoId = item, UsuarioId = usuario.Id });
            }

            _uow.BeginTransaction();
            usuario = _usuarioService.Atualizar(usuario);

            if (usuario.ValidationResult.IsValid)
                _uow.Commit();

            return usuario;
        }

        public bool Deletar(Guid Id)
        {
            _uow.BeginTransaction();
            var retorno = _usuarioService.Deletar(Id);
            if (retorno)
                _uow.Commit();

            return retorno;
        }

        public Usuario CadastrarSenha(CadastrarSenhaModel cadastrarSenhaModel)
        {
            var usuario = Mapper.Map<CadastrarSenhaModel, Usuario>(cadastrarSenhaModel);
            _uow.BeginTransaction();

            usuario = _usuarioService.CadastrarNovaSenha(usuario);
            if (usuario.ValidationResult.IsValid)
                _uow.Commit();

            return usuario;
        }

        public bool ZerarSenha(Guid Id)
        {
            _uow.BeginTransaction();
            var retorno = _usuarioService.ZerarSenha(Id);
            if (retorno)
                _uow.Commit();

            return retorno;
        }

        public IEnumerable<Usuario> Listar()
        {
            return _usuarioRepository.Listar();
        }

        public ObterUsuarioModel Obter(Guid Id)
        {
            var usuario = _usuarioRepository.ObterPorId(Id);           
            return new UsuarioAdapter().UsuarioParaObterUsuarioModel(usuario);
        }


        public Usuario TrocarSenha(TrocarSenha trocarSenha)
        {
             ClaimsIdentity claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;           
             var usuario = _usuarioRepository.ObterPorId(Guid.Parse(claimsIdentity.FindFirst("userId").Value));
             usuario.Senha = trocarSenha.Senha;

             _uow.BeginTransaction();
             usuario = _usuarioService.Atualizar(usuario);

             if (usuario.ValidationResult.IsValid)
                 _uow.Commit();

             return usuario;            
        }
    }
}
