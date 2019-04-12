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
    public class RelatorioRepository : Repository<Relatorio>, IRelatorioRepository
    {
        private readonly DbConnection _cn;
        public RelatorioRepository(EntityContext entity)
            : base(entity)
        {
            _cn = Db.Database.Connection;
        }
        public IEnumerable<Relatorio> ListarPorUsuario()
        {
            var sql = @"select COUNT(u.Id) as 'Quantidade', u.Id, u.Nome + ' ' + u.SobreNome as 'Nome' from Errata e
                        inner join Usuario u
                        on e.ResponsavelInsercaoId = u.Id
                        group by  u.Id, u.Nome,  u.SobreNome";

           return _cn.Query<Relatorio>(sql);
        }

        public IEnumerable<Relatorio> ListarPorDepartamento()
        {
            var sql = @"select COUNT(m.Id) as 'Quantidade', m.Id, m.Descricao as 'Nome' from Errata e
                        inner join MotivoErrata m
                        on e.MotivoErrataId = m.Id
                        group by  m.Id, m.Descricao";

            return _cn.Query<Relatorio>(sql);
        }
    }
}
