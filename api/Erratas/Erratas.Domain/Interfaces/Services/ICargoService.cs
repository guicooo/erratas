using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Interfaces.Services
{
    public interface ICargoService
    {
        Cargo Cadastrar(Cargo cargo);
        Cargo Atualizar(Cargo cargo);
        Cargo Deletar(Guid Id);        
    }
}
