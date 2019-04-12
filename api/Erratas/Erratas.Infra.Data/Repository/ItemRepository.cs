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
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly DbConnection _cn;
        public ItemRepository(EntityContext entity)
            : base(entity)
        {
            _cn = Db.Database.Connection;
        }
    }
}
