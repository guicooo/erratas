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
    public class PermissaoAppService : IPermissaoAppService
    {
        private readonly IPermissaoRepository _permissaoRepository;
        public PermissaoAppService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }
        public IEnumerable<Permissao> Listar()
        {
            return _permissaoRepository.Listar();
        }
    }
}
