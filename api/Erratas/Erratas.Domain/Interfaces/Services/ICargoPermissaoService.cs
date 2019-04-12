using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Services
{
    public interface ICargoPermissaoService
    {
        IEnumerable<CargoPermissao> Obter(Guid Id);
        CargoPermissao Atualizar(CargoPermissao cargoPermissao);
        CargoPermissaoModulo AtualizarPorModulo(CargoPermissaoModulo cargoPermissao);       
        bool CadastrarTodasAsPermissoes(Cargo cargo);

    }
}
