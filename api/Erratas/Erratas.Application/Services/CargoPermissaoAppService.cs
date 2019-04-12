using AutoMapper;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Application.Models.Cargos;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Services;
using Erratas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class CargoPermissaoAppService : ICargoPermissaoAppService
    {
        private readonly ICargoPermissaoService _cargoPermissaoService;
        private readonly IUnitOfWork _uow;
        public CargoPermissaoAppService(ICargoPermissaoService cargoPermissaoService, IUnitOfWork uow)
        {
            _cargoPermissaoService = cargoPermissaoService;
            _uow = uow;
        }
        public CargoPermissao Autorizacao(CargoPermissaoModel cargoPermissaoModel)
        {
            var permissao = Mapper.Map<CargoPermissaoModel, CargoPermissao>(cargoPermissaoModel);

            _uow.BeginTransaction();

            var cargoPermissao = _cargoPermissaoService.Atualizar(permissao);
            if (cargoPermissao.ValidationResult.IsValid)
                _uow.Commit();

            return cargoPermissao;
        }
        public CargoPermissaoModulo AutorizacaoPorModulo(CargoPermissaoModuloModel cargoPermissaoModuloModel)
        {
            var permissao = Mapper.Map<CargoPermissaoModuloModel, CargoPermissaoModulo>(cargoPermissaoModuloModel);

            _uow.BeginTransaction();

            var cargoPermissao = _cargoPermissaoService.AtualizarPorModulo(permissao);
            if (cargoPermissao.ValidationResult.IsValid)
                _uow.Commit();

            return cargoPermissao;
        }
    }
}
