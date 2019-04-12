using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ValidarUsuario(string email, string senha);
        Usuario ObterPorEmail(string email);      
        IEnumerable<string> ObterPermissoes(Guid CargoId);
        IEnumerable<Usuario> ObterUsuariosPorCargo(Guid CargoId);
        IEnumerable<Guid> ObterUsuariosPorCurso(string CursoId);
    }
}
