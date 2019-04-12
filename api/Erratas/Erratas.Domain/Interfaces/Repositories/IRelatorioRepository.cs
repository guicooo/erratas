using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Repositories
{
    public interface IRelatorioRepository : IRepository<Relatorio>
    {
        IEnumerable<Relatorio> ListarPorUsuario();
        IEnumerable<Relatorio> ListarPorDepartamento();
    }
}
