using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Menu;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class MenuAppService : IMenuAppService
    {
        private readonly ICargoPermissaoRepository _cargoPermissaoRepository;
        public MenuAppService(ICargoPermissaoRepository cargoPermissaoRepository)
        {
            _cargoPermissaoRepository = cargoPermissaoRepository;
        }
        public MenuModel Listar()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var cargo = Guid.Parse(identity.Claims.Where(x => x.Type.ToLower() == "cargoid").SingleOrDefault().Value);
            var permissoes = _cargoPermissaoRepository.ObterPermissoesPorCargo(cargo);
            return new MenuAdapter().CargoPermissaoParaMenuModel(permissoes);            
        }
    }
}
