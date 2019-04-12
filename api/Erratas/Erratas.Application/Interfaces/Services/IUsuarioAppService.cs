using Erratas.Application.Models;
using Erratas.Application.Models.Usuarios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IUsuarioAppService
    {
        IEnumerable<Usuario> Listar();
        ObterUsuarioModel Obter(Guid Id);
        Usuario Cadastrar(UsuarioModel usuarioModel);
        Usuario Atualizar(Guid Id, UsuarioAtualizarModel usuarioModel);
        bool Deletar(Guid Id);
        Usuario CadastrarSenha(CadastrarSenhaModel cadastrarSenhaModel);
        Usuario TrocarSenha(TrocarSenha trocarSenha);
        bool ZerarSenha(Guid Id);
    }
}
