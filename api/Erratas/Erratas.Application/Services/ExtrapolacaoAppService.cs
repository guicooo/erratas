using Erratas.Application.Interfaces.Services;
using Erratas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Application.Services
{
    public class ExtrapolacaoAppService : IExtrapolacaoAppService
    {
        private readonly IExtrapolacaoService _extrapolacaoService;
        public ExtrapolacaoAppService(IExtrapolacaoService extrapolacaoService)
        {
            _extrapolacaoService = extrapolacaoService;
        }
        public bool ExtrapolarGrade(HttpPostedFile arquivo)
        {
            return _extrapolacaoService.ExtrapolarGrade(arquivo);
        }
    }
}
