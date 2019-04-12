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
    public class CursoDisciplinaRepository : Repository<CursoDisciplina>, ICursoDisciplinaRepository
    {
        private readonly DbConnection _cn;
        public CursoDisciplinaRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }
        public IEnumerable<CursoDisciplina> ObterPorModelo(string modelo)
        {
            return DbSet.AsNoTracking().Include("Curso").Include("Disciplina").Where(x => x.CodigoModelo == modelo).ToList();           
        }
       
    }
}
