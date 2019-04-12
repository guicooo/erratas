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
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        private readonly DbConnection _cn;
        public CargoRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public Cargo CargoExiste(Guid Id)
        {
            var sql = "select * from cargo where id = '" + Id + "'";
            return _cn.Query<Cargo>(sql).FirstOrDefault();
        }

        public Cargo NomeExiste(string Nome)
        {
            return DbSet.Where(x => x.Nome.ToLower() == Nome.ToLower()).FirstOrDefault();
        }

        public override IEnumerable<Cargo> Listar()
        {
            var sql = @"select * from cargo c where c.ativo = 1";
            return _cn.Query<Cargo>(sql); 
        }
    }
}
