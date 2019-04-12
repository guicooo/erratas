using Erratas.Application.Models.Erratas;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IErrataAppService
    {
        IEnumerable<ObterErrataModel> Listar();
        ObterErrataModel Obter(Guid Id);
        Errata Cadastrar();
        Errata Atualizar(Guid Id);
        IEnumerable<string> RetornarUsuarios(Errata errata);
    }
}
