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
    public class InstitutoAppService : IInstitutoAppService
    {
        private readonly IInstitutoRepository _institutoRepository;
        public InstitutoAppService(IInstitutoRepository institutoRepository)
        {
            _institutoRepository = institutoRepository;
        }
        public IEnumerable<Instituto> Listar()
        {
            return _institutoRepository.Listar();
        }
    }
}
