using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Repository
{
    public class UsuarioCursoRepository : Repository<UsuarioCurso>, IUsuarioCursoRepository
    {
        private readonly DbConnection _cn;
        public UsuarioCursoRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }       
        public IEnumerable<UsuarioCurso> ListarPorUsuario(Guid Id)
        {
            return DbSet.Where(x => x.UsuarioId == Id).ToList();
        }
    }
}
