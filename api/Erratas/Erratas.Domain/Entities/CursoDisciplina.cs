using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class CursoDisciplina
    {       
        public Guid Id { get; set; }
        public string CodigoModelo { get; set; }
        public string CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public string DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
