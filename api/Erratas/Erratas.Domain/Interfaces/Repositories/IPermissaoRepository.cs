using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface IPermissaoRepository : IRepository<Permissao>
    {
        IEnumerable<Permissao> ObterPermissoesPorModulo(Guid ModuloId);
    }
}
