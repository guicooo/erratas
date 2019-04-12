using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Curso ObterPorId(string Id);
    }
}
