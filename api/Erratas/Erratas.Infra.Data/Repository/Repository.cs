using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected EntityContext Db;
        protected DbSet<T> DbSet;
        public Repository(EntityContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }
        public virtual T ObterPorId(Guid Id)
        {
            var entity = DbSet.Find(Id);          
            return entity;           
        }
               
        public virtual IEnumerable<T> Listar()
        {
            Db.Configuration.LazyLoadingEnabled = true;
            return DbSet.ToList();
        }

        public T Cadastrar(T Entity)
        {
            var returnObj = DbSet.Add(Entity);
            return returnObj;
        }
        public int Salvar()
        {
            return Db.SaveChanges();                     
        }

        public T Atualizar(T Entity)
        {                      
            var entry = Db.Entry(Entity);
            DbSet.Attach(Entity);
            entry.State = EntityState.Modified;
            
            return Entity;
        }
        public bool Deletar(Guid Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            return true;
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        public void Detach(T Entity)
        {
            Db.Entry(Entity).State = EntityState.Detached;
        }
    }
}
