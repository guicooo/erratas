using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> Listar();
        Usuario Cadastrar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        Usuario CadastrarNovaSenha(Usuario usuario);
        bool Deletar(Guid Id);
        bool ZerarSenha(Guid Id);       
    }
}
