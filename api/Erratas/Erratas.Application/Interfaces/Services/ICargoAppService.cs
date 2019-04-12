using Erratas.Application.Models;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface ICargoAppService
    {
        IEnumerable<Cargo> Listar();
        Cargo Cadastrar(CargoModel cargoModel);
        Cargo Atualizar(Guid Id, CargoAtualizarModel cargoModel);
        Cargo Deletar(Guid Id);
        ObterCargoModel Obter(Guid Id);   
    }
}
