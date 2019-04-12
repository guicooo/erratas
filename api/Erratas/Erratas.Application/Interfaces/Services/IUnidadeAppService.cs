using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IUnidadeAppService
    {
        IEnumerable<Unidade> Listar();
    }
}
