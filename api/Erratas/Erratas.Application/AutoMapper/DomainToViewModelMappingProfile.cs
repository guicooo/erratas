using AutoMapper;
using Erratas.Application.Models;
using Erratas.Application.Models.Cargos;
using Erratas.Application.Models.Logs;
using Erratas.Application.Models.Relatorios;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioModel>();
            Mapper.CreateMap<Usuario, UsuarioAtualizarModel>();
            Mapper.CreateMap<Usuario, CadastrarSenhaModel>();
            Mapper.CreateMap<Cargo, CargoAtualizarModel>();
            Mapper.CreateMap<Cargo, CargoModel>();
            Mapper.CreateMap<CargoPermissao, CargoPermissaoModel>();
            Mapper.CreateMap<CargoPermissaoModulo, CargoPermissaoModuloModel>();
            Mapper.CreateMap<Log, ObterLogModel>();
            Mapper.CreateMap<Relatorio, RelatorioUsuarioModel>();
            Mapper.CreateMap<Relatorio, RelatorioDepartamentoModel>();
        }
    }
}
