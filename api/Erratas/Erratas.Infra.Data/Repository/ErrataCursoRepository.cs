using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Repository
{
    public class ErrataCursoRepository : Repository<ErrataCurso>, IErrataCursoRepository
    {
        public ErrataCursoRepository(EntityContext context)
            :base(context)
        {

        }
    }
}
