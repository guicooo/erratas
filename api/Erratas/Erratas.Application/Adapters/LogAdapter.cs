using AutoMapper;
using Erratas.Application.Models;
using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Logs;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class LogAdapter
    {
        public ObterLogModel LogParaObterLogModel(Log log)
        {
            var obterLogModel = new ObterLogModel();      
     
            obterLogModel.Usuario.Nome = log.Usuario.Nome;
            obterLogModel.Usuario.SobreNome = log.Usuario.SobreNome;
            obterLogModel.Usuario.Email = log.Usuario.Email;
            obterLogModel.Id = log.Id;
            obterLogModel.Retorno = log.Retorno;
            obterLogModel.Status = log.Status;
            obterLogModel.Url = log.Url;
            obterLogModel.Verbo = log.Verbo;
            obterLogModel.Acao = log.Acao;
            obterLogModel.Controller = log.Controller;
            obterLogModel.DataDeGravacao = log.DataDeGravacao;            
            
            obterLogModel.Usuario.Cargo = new CargoModel() { Nome = log.Usuario.Cargo.Nome, Id = log.Usuario.Cargo.Id };

            foreach (var item in log.Usuario.UsuarioCursos)
            {
                obterLogModel.Usuario.Cursos.Add(new CursoModel() { Id = item.Curso.Id, Nome = item.Curso.Nome });
            }
           
            return obterLogModel;
        }
    }
}
