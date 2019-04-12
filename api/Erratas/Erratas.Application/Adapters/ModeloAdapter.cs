using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Application.Models.Modelo;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Adapters
{
    public class ModeloAdapter
    {
        public ModeloAdapter()
        {

        }

        public ModeloModel CursoDisciplinaParaModelo(IEnumerable<CursoDisciplina> cursoDisciplinas)
        {
            var modelo = new ModeloModel();
            
            if(cursoDisciplinas.Count() == 0)
                return modelo;

            modelo.Modelo = cursoDisciplinas.First().CodigoModelo;

            foreach(var item in cursoDisciplinas)
            {
                modelo.Cursos.Add(new CursoModel() { Id = item.Curso.Id, Nome = item.Curso.Nome });
                modelo.Disciplinas.Add(new DisciplinaModeloModel() { Id = item.Disciplina.Id, Nome = item.Disciplina.Nome });
            }

            // Remove os duplicados
            modelo.Disciplinas = modelo.Disciplinas.GroupBy(x => x.Id).Select(g => g.First()).ToList();

            return modelo;
        }
    }
}
