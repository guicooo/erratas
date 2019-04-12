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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly DbConnection _cn;
        public UsuarioRepository(EntityContext context)
            : base(context)
        {
            _cn = Db.Database.Connection;
        }

        public override IEnumerable<Usuario> Listar()
        {
            var sql = @"select * from usuario u inner join cargo c on c.id = u.cargoId where u.ativo = 1";
            var retorno = _cn.Query<Usuario, Cargo, Usuario>(sql, (u, c) => 
                                                            {
                                                                u.Cargo = c;               
                                                                return u; 
                                                            }, splitOn: "CargoId" );
            return retorno;
        }

        public Usuario ValidarUsuario(string email, string senha)
        {
            return DbSet.Include("Cargo").Where(x => x.Email == email).FirstOrDefault();
        }

        public Usuario ObterPorEmail(string email)
        {
            return DbSet.Where(x => x.Email == email).FirstOrDefault();
        }

        public IEnumerable<string> ObterPermissoes(Guid CargoId)
        {
            var sql = @"select p.Abreviacao from 
                       cargoPermissao cp inner join permissao p on cp.PermissaoId = p.Id  
                       where cp.cargoId = '" + CargoId + "' and cp.autorizado = 1 ";

            return _cn.Query<string>(sql);
        }        
        public IEnumerable<Usuario> ObterUsuariosPorCargo(Guid CargoId)
        {
            var sql = "select * from usuario where cargoid = '" + CargoId + "' ";
            return _cn.Query<Usuario>(sql);
        }


        public IEnumerable<Guid> ObterUsuariosPorCurso(string CursoId)
        {
            var sql = @"select u.Id from UsuarioCurso uc 
                        inner join Curso c on uc.CursoId = c.Id
                        inner join Usuario u on uc.UsuarioId = u.Id
                        where c.Id = '" + CursoId + "'";

            return _cn.Query<Guid>(sql); 
        }
    }
}
