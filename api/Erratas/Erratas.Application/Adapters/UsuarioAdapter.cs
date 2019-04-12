using Erratas.Application.Models;
using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Menu;
using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class UsuarioAdapter
    {
        public ObterUsuarioModel UsuarioParaObterUsuarioModel(Usuario usuario)
        {
            var obterUsuarioModel = new ObterUsuarioModel();
            obterUsuarioModel.Id = usuario.Id;
            obterUsuarioModel.Nome = usuario.Nome;
            obterUsuarioModel.SobreNome = usuario.SobreNome;
            obterUsuarioModel.Email = usuario.Email;
            obterUsuarioModel.Departamento = usuario.Departamento;
            obterUsuarioModel.Cargo = new CargoModel() { Nome = usuario.Cargo.Nome, Id = usuario.Cargo.Id };

            foreach(var item in usuario.UsuarioCursos)
            {
                obterUsuarioModel.Cursos.Add(new CursoModel() { Id = item.Curso.Id, Nome = item.Curso.Nome });
            }
            
            return obterUsuarioModel;
        }
    }
}
