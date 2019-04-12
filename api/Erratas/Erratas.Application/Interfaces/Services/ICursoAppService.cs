using Erratas.Application.Models.Cursos;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Interfaces.Services
{
    public interface ICursoAppService
    {
        IEnumerable<Curso> Listar();
        Curso Obter(string Id);
        Curso Cadastrar(CursoModel cursoModel);
        Curso Atualizar(string Id, AtualizarCursoModel cursoModel);
        bool Deletar(string Id);
    }
}
