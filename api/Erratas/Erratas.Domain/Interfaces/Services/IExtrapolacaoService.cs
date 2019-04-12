using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Erratas.Domain.Interfaces.Services
{
    public interface IExtrapolacaoService
    {
        bool ExtrapolarGrade(HttpPostedFile arquivo);
    }
}
