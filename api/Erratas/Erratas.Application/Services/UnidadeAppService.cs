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
    public class UnidadeAppService : IUnidadeAppService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        public UnidadeAppService(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }
        public IEnumerable<Unidade> Listar()
        {
            return _unidadeRepository.Listar();
        }
    }
}
