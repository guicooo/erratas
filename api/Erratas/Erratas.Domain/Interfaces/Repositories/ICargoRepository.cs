using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        Cargo CargoExiste(Guid Id);
        Cargo NomeExiste(string Nome);        
    }
}
