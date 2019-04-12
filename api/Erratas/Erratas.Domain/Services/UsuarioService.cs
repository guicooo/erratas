using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioCursoRepository _usuarioCursoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public UsuarioService(
            IUsuarioRepository usuarioRepository, 
            ICargoRepository cargoRepository, 
            ICursoRepository cursoRepository,
            IUsuarioCursoRepository usuarioCursoRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cargoRepository = cargoRepository;
            _cursoRepository = cursoRepository;
            _usuarioCursoRepository = usuarioCursoRepository;
            _departamentoRepository = departamentoRepository;
        }

        public IEnumerable<Usuario> Listar()
        {
            return _usuarioRepository.Listar();
        }

        public Usuario Cadastrar(Usuario usuario)
        {            
            if (!usuario.EhValido())
                return usuario;

            usuario.ValidationResult = new CadastrarUsuarioValidator(_departamentoRepository, _usuarioRepository, _cargoRepository, _cursoRepository).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
                return usuario;
        
            return _usuarioRepository.Cadastrar(usuario);           
        }

        public Usuario Atualizar(Usuario usuario)
        {           
            if (!usuario.EhValido())
                return usuario;


            usuario.Ativo = true;
            usuario.ValidationResult = new AtualizarUsuarioValidator(_departamentoRepository, _usuarioRepository, _cargoRepository, _cursoRepository).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
                return usuario;

            var aux = _usuarioRepository.ObterPorId(usuario.Id);
            var usuarioCursos = new List<Guid>();

            foreach(var item in aux.UsuarioCursos)           
                usuarioCursos.Add(item.Id);
            
            if(string.IsNullOrEmpty(usuario.Senha))
                usuario.Senha = aux.Senha;

            _usuarioRepository.Detach(aux);
            
            // Deleta os cursos antigos, para cadastrar os novos
            foreach (var item in usuarioCursos)           
                _usuarioCursoRepository.Deletar(item);

            // Cadastra os novos
            foreach(var item in usuario.UsuarioCursos)            
                _usuarioCursoRepository.Cadastrar(item);
            
            return _usuarioRepository.Atualizar(usuario);
        }

        public Usuario CadastrarNovaSenha(Usuario usuario)
        {
            usuario.ValidationResult = new NovaSenhaValidator(_usuarioRepository).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
                return usuario;
           
            var usuarioNovo = _usuarioRepository.ObterPorEmail(usuario.Email);
            usuarioNovo.Senha = usuario.Senha;

            _usuarioRepository.Atualizar(usuarioNovo);
          
            return usuario;
        }

        public bool Deletar(Guid Id)
        {
            var usuario = _usuarioRepository.ObterPorId(Id);
            if (usuario == null)
                return false;

            usuario.Ativo = false;
            _usuarioRepository.Atualizar(usuario);
          
            return true;
        }

        public bool ZerarSenha(Guid Id)
        {
            var usuario = _usuarioRepository.ObterPorId(Id);
            if (usuario == null)
                return false;

            usuario.Senha = null;                
            _usuarioRepository.Atualizar(usuario);

            return true;
        }
    }    
}
