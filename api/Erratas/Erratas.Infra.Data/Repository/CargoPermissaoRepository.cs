using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.Common;
using Erratas.Infra.Data.Context;

namespace Erratas.Infra.Data.Repository
{
    public class CargoPermissaoRepository : Repository<CargoPermissao>, ICargoPermissaoRepository
    {
        private readonly DbConnection _cn;
        public CargoPermissaoRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public IEnumerable<CargoPermissao> ObterPermissoesPorCargo(Guid CargoId)
        {
            return DbSet.Include("Cargo").Include("Permissao").Where(x => x.CargoId == CargoId).ToList();
        }

        public CargoPermissao ObterPermissaoPorCargoEPermissao(Guid CargoId, Guid PermissaoId)
        {
            return DbSet.Include("Cargo").Include("Permissao").Where(x => x.CargoId == CargoId && x.PermissaoId == PermissaoId).FirstOrDefault();
        }
    }
}
