using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations;
using Erratas.Domain.Validations.CargoPermissao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class CargoPermissaoService : ICargoPermissaoService
    {
         
        private readonly ICargoPermissaoRepository _cargoPermissaoRepository;
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IModuloRepository _moduloRepository;
        public CargoPermissaoService(ICargoPermissaoRepository cargoPermissaoRepository, 
            IPermissaoRepository permissaoRepository,
            ICargoRepository cargoRepository,
            IModuloRepository moduloRepository)
        {          
            _cargoPermissaoRepository = cargoPermissaoRepository;
            _permissaoRepository = permissaoRepository;
            _cargoRepository = cargoRepository;
            _moduloRepository = moduloRepository;
          
        }
        public IEnumerable<CargoPermissao> Obter(Guid Id)
        {
            return _cargoPermissaoRepository.ObterPermissoesPorCargo(Id);
        }

        public CargoPermissao Atualizar(CargoPermissao cargoPermissao)
        {
            cargoPermissao.ValidationResult = new AtualizarCargoPermissaoValidator(_permissaoRepository, _cargoRepository).Validate(cargoPermissao);
            if (!cargoPermissao.ValidationResult.IsValid)
                return cargoPermissao;

            var obj = _cargoPermissaoRepository.ObterPermissaoPorCargoEPermissao(cargoPermissao.CargoId, cargoPermissao.PermissaoId);

            obj.ValidationResult = cargoPermissao.ValidationResult;
            obj.Autorizado = cargoPermissao.Autorizado;

            return _cargoPermissaoRepository.Atualizar(obj); 
        }

        public CargoPermissaoModulo AtualizarPorModulo(CargoPermissaoModulo cargoPermissao)
        {
            cargoPermissao.ValidationResult = new AtualizarCargoPermissaoModuloValidator(_cargoRepository, _moduloRepository).Validate(cargoPermissao);
            if (!cargoPermissao.ValidationResult.IsValid)
                return cargoPermissao;

            var permissoes = _permissaoRepository.ObterPermissoesPorModulo(cargoPermissao.ModuloId);
            foreach(var item in permissoes)
            {
                var cargoPermissaoBanco = _cargoPermissaoRepository.ObterPermissaoPorCargoEPermissao(cargoPermissao.CargoId, item.Id);
                cargoPermissaoBanco.Autorizado = cargoPermissao.Autorizado;
                _cargoPermissaoRepository.Atualizar(cargoPermissaoBanco);               
            }            

            return cargoPermissao;
        }
        
        public bool CadastrarTodasAsPermissoes(Cargo cargo)
        {
            var permissoes = _permissaoRepository.Listar();

            foreach(var item in permissoes)
            {
                var cargoPermissao = new CargoPermissao() 
                {
                    Id = Guid.NewGuid(),
                    PermissaoId = item.Id,
                    CargoId = cargo.Id,
                    Autorizado = false
                };
                              
                _cargoPermissaoRepository.Cadastrar(cargoPermissao);               
            }

            return true;
        }
    }
}
