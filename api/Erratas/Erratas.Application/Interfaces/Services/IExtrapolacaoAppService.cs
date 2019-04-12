using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Application.Interfaces.Services
{
    public interface IExtrapolacaoAppService
    {
        bool ExtrapolarGrade(HttpPostedFile arquivo);
    }
}
