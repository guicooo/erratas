using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Erratas.Infra.Data.Repository
{
    public class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
         private readonly DbConnection _cn;
         public PermissaoRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public override IEnumerable<Permissao> Listar()
        {
            var sql = "select * from permissao";
            return _cn.Query<Permissao>(sql); 
        }

        public IEnumerable<Permissao> ObterPermissoesPorModulo(Guid ModuloId)
        {
            return Db.Permissoes.Where(x => x.ModuloId == ModuloId).ToList();
        }
    }
}
