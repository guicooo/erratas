using AutoMapper;
using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class CargoAppService : ICargoAppService
    {
        private readonly ICargoService _cargoService;
        private readonly ICargoPermissaoService _cargoPermissaoService;        
        private readonly ICargoPermissaoAppService _permissaoService;
        private readonly ICargoRepository _cargoRepository;
        private readonly IUnitOfWork _uow;
        public CargoAppService(ICargoService cargoService,   
            ICargoPermissaoService cargoPermissaoService,          
            ICargoPermissaoAppService permissaoService,
            ICargoRepository cargoRepository,
            IUnitOfWork uow)
        {
            _cargoService = cargoService;
            _permissaoService = permissaoService;
            _cargoPermissaoService = cargoPermissaoService;
            _cargoRepository = cargoRepository;
            _uow = uow;
        }       
        public Cargo Cadastrar(CargoModel cargoModel)
        {
            var cargo = Mapper.Map<CargoModel, Cargo>(cargoModel);
            cargo.Id = Guid.NewGuid();

            _uow.BeginTransaction();

            cargo = _cargoService.Cadastrar(cargo);
            if (cargo.ValidationResult.IsValid)
                _uow.Commit();

            return cargo;       
        }

        public Cargo Atualizar(Guid Id, CargoAtualizarModel cargoModel)
        {                          
            var cargo = Mapper.Map<CargoAtualizarModel, Cargo>(cargoModel);
            cargo.Id = Id;

            _uow.BeginTransaction();

            cargo = _cargoService.Atualizar(cargo);
            if (cargo.ValidationResult.IsValid)
                _uow.Commit();

            return cargo;       
        }

        public Cargo Deletar(Guid Id)
        {
            _uow.BeginTransaction();

            var cargo = _cargoService.Deletar(Id);

            if (cargo.ValidationResult.IsValid)
                _uow.Commit();

            return cargo;       
        }
        public ObterCargoModel Obter(Guid Id)
        {
            var permissoes = _cargoPermissaoService.Obter(Id);
            return new CargoPermissaoAdapter().CargoPermissaoParaObterCargoModel(permissoes);
        }
        public IEnumerable<Cargo> Listar()
        {
            return _cargoRepository.Listar();
        }
    }
}
