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
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly DbConnection _cn;
        public LogRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public override IEnumerable<Log> Listar()
        {
            var sql = @"select * from log";
            return _cn.Query<Log>(sql); 
        }

        public override Log ObterPorId(Guid Id)
        {
            return DbSet.FirstOrDefault();
        }
    }
}
