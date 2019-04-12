using Erratas.Application.Interfaces.Services;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class DepartamentoAppService : IDepartamentoAppService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoAppService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        public IEnumerable<Departamento> Listar()
        {
            return _departamentoRepository.Listar();
        }
    }
}
