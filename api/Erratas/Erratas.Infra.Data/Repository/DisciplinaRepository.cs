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
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        private readonly DbConnection _cn;
        public DisciplinaRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public override IEnumerable<Disciplina> Listar()
        {
            var sql = "select * from disciplina where ativo = 1";
            return _cn.Query<Disciplina>(sql);
        }

        public Disciplina ObterPorId(string Id)
        {
            return DbSet.Include("CursoDisciplinas").Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
