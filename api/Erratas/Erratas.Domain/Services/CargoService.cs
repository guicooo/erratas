using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using Erratas.Domain.Interfaces.Services;
using Erratas.Domain.Validations;
using Erratas.Domain.Validations.Cargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICargoPermissaoService _cargoPermissaoService;
        public CargoService(ICargoRepository cargoRepository, IUsuarioRepository usuarioRepository, ICargoPermissaoService cargoPermissaoService)
        {
            _cargoRepository = cargoRepository;
            _usuarioRepository = usuarioRepository; 
            _cargoPermissaoService = cargoPermissaoService;
        }       
        public Cargo Cadastrar(Cargo cargo)
        {
            if (!cargo.EhValido())
                return cargo;

            cargo.ValidationResult = new CadastrarCargoValidator(_cargoRepository).Validate(cargo);

            if (!cargo.ValidationResult.IsValid)
                return cargo;

            _cargoRepository.Cadastrar(cargo);          
            _cargoPermissaoService.CadastrarTodasAsPermissoes(cargo);

            return cargo;    
        }

        public Cargo Atualizar(Cargo cargo)
        {
            if (!cargo.EhValido())
                return cargo;

            cargo.ValidationResult = new AtualizarCargoValidator(_cargoRepository).Validate(cargo);

            if (!cargo.ValidationResult.IsValid)
                return cargo;

            return _cargoRepository.Atualizar(cargo);
        }
        public Cargo Deletar(Guid Id)
        {
            var cargo = _cargoRepository.ObterPorId(Id);
            cargo.ValidationResult = new DeletarCargoValidator(_usuarioRepository, _cargoRepository).Validate(cargo);

            if (!cargo.ValidationResult.IsValid)                           
                return cargo;
            
            cargo.Ativo = false;

            return _cargoRepository.Atualizar(cargo);
        }
    }
}
