using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface ICargoPermissaoRepository : IRepository<CargoPermissao>
    {
        IEnumerable<CargoPermissao> ObterPermissoesPorCargo(Guid CargoId);
        CargoPermissao ObterPermissaoPorCargoEPermissao(Guid CargoId, Guid PermissaoId);
    }
}
