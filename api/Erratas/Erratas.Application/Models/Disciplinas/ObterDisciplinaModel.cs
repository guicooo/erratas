using Erratas.Application.Models.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Disciplinas
{
    public class ObterDisciplinaModel
    {
        public ObterDisciplinaModel()
        {
            Cursos = new List<CursoModel>();
        }      
        public string Id { get; set; }        
        public string CodigoModelo { get; set; }       
        public string Nome { get; set; }        
        public ICollection<CursoModel> Cursos { get; set; }
    }
}
