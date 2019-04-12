using AutoMapper;
using Erratas.Application.Models;
using Erratas.Application.Models.Cargos;
using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioModel, Usuario>();
            Mapper.CreateMap<UsuarioAtualizarModel, Usuario>();
            Mapper.CreateMap<CadastrarSenhaModel, Usuario>();
            Mapper.CreateMap<CargoAtualizarModel, Cargo>();
            Mapper.CreateMap<CargoModel, Cargo>();
            Mapper.CreateMap<CargoPermissaoModel, CargoPermissao>();
            Mapper.CreateMap<CargoPermissaoModuloModel, CargoPermissaoModulo>();
            Mapper.CreateMap<DisciplinaModel, Disciplina>();
            Mapper.CreateMap<AtualizarDisciplinaModel, Disciplina>();
            Mapper.CreateMap<CursoModel, Curso>();
            Mapper.CreateMap<AtualizarCursoModel, Curso>(); 
        }
    }
}
