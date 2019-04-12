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
    public class MotivoErrataAppService : IMotivoErrataAppService
    {
        private readonly IMotivoErrataRepository _motivoErrataRepository;
        public MotivoErrataAppService(IMotivoErrataRepository motivoErrataRepository)
        {
            _motivoErrataRepository = motivoErrataRepository;
        }


        public IEnumerable<MotivoErrata> Listar()
        {
            return _motivoErrataRepository.Listar();
        }
    }
}
