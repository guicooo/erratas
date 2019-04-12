using Erratas.Application.Adapters;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Modelo;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class ModeloAppService : IModeloAppService
    {
        private readonly ICursoDisciplinaRepository _modeloRepository;
        public ModeloAppService(ICursoDisciplinaRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }
        public ModeloModel Obter(string modelo)
        {
            var retorno = _modeloRepository.ObterPorModelo(modelo);
            return new ModeloAdapter().CursoDisciplinaParaModelo(retorno);
        }
    }
}
