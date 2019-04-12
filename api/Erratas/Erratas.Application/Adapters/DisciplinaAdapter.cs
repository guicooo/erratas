using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class DisciplinaAdapter
    {
        public ObterDisciplinaModel DisciplinaParaObterDisciplinaModel(Disciplina disciplina)
        {
            var disciplinaModel = new ObterDisciplinaModel();

            disciplinaModel.Id = disciplina.Id;
            disciplinaModel.Nome = disciplina.Nome;
            disciplinaModel.CodigoModelo = disciplina.CursoDisciplinas.FirstOrDefault().CodigoModelo;

            foreach(var item in disciplina.CursoDisciplinas)
            {
                disciplinaModel.Cursos.Add(new CursoModel() { Id = item.Curso.Id, Nome = item.Curso.Nome });
            }

            return disciplinaModel;
        }
    }
}
