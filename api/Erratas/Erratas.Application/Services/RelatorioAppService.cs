using AutoMapper;
using Erratas.Application.Interfaces.Services;
using Erratas.Application.Models.Relatorios;
using Erratas.Domain.Entities;
using Erratas.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        public RelatorioAppService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }
        public IEnumerable<Relatorio> ListarPorUsuario()
        {
            return _relatorioRepository.ListarPorUsuario();
        }

        public IEnumerable<Relatorio> ListarPorDepartamento()
        {
            return _relatorioRepository.ListarPorDepartamento();
        }

        public IEnumerable<RelatorioModel> ListarTodos()
        {
            var relatorioModel = new List<RelatorioModel>();
            var lstUsuarios = _relatorioRepository.ListarPorUsuario();
            var usuario = new List<RelatorioUsuarioModel>();
            var lstDepartamento = _relatorioRepository.ListarPorDepartamento();
            var departamento =  new List<RelatorioDepartamentoModel>();
            foreach(var item in lstUsuarios)
            {
                usuario.Add(Mapper.Map<Relatorio, RelatorioUsuarioModel>(item));
            }
            foreach (var item in lstDepartamento)
            {
                departamento.Add(Mapper.Map<Relatorio, RelatorioDepartamentoModel>(item));
            }
          
            relatorioModel.Add(new RelatorioModel() { Tipo = "Departamento", Departamento = departamento });
            relatorioModel.Add(new RelatorioModel() { Tipo = "Usuario", Usuario = usuario });

            return relatorioModel; 
        }

    }
}
