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
    public class MensagemRepository : Repository<Mensagem>, IMensagemRepository
    {
        private readonly DbConnection _cn;
        public MensagemRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }


        public IEnumerable<Mensagem> ObterPorUsuario(Guid UsuarioId)
        {
            var sql = @"select * from mensagem where usuarioid = '" + UsuarioId + "' ";
            return _cn.Query<Mensagem>(sql);
        }
    }
}
