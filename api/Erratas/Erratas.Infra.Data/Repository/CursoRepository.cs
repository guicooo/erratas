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
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        private readonly DbConnection _cn;
        public CursoRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public override IEnumerable<Curso> Listar()
        {
            var sql = "select * from curso where ativo = 1";
            return _cn.Query<Curso>(sql);
        }

        public Curso ObterPorId(string Id)
        {
            return DbSet.Where(x => x.Id == Id).FirstOrDefault();
        }        
    }
}
