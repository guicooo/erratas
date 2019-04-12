using Erratas.Application.Models.Modelo;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface IModeloAppService
    {
        ModeloModel Obter(string modelo);
    }
}
