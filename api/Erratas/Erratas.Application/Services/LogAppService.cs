using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Logs;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class LogAppService : ILogAppService
    {
        private readonly ILogRepository _logRepository;
        public LogAppService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public IEnumerable<Log> Listar()
        {
            return _logRepository.Listar();
        }

        public ObterLogModel Obter(Guid Id)
        {
            var log = _logRepository.ObterPorId(Id);
            return new LogAdapter().LogParaObterLogModel(log);
        }
    }
}
