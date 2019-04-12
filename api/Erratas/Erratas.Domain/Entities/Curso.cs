using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Curso
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
        public ICollection<UsuarioCurso> UsuarioCursos { get; set; }
        public ICollection<ErrataCurso> ErrataCursos { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }     
  
    }
}
