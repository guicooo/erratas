using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;
        public PermissaoService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }
        public IEnumerable<Permissao> Listar()
        {
            return _permissaoRepository.Listar();
        }
    }
}
