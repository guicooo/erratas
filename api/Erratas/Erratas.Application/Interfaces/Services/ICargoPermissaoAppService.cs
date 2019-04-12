using Erratas.Application.Models;
using Erratas.Application.Models.Cargos;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface ICargoPermissaoAppService
    {
        CargoPermissao Autorizacao(CargoPermissaoModel cargoPermissaoModel);
        CargoPermissaoModulo AutorizacaoPorModulo(CargoPermissaoModuloModel cargoPermissaoModel);
    }
}
