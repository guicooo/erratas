using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Disciplinas;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Modelo
{
    public class ModeloModel
    {
        public ModeloModel()
        {
            Cursos = new List<CursoModel>();
            Disciplinas = new List<DisciplinaModeloModel>();
        }
        public string Modelo { get; set; }
        public ICollection<CursoModel> Cursos { get; set; }
        public ICollection<DisciplinaModeloModel> Disciplinas { get; set; }
    }
}
