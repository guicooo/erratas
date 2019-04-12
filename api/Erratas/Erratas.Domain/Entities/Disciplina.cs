using Erratas.Domain.Validations.Disciplina;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Disciplina
    {
        public Disciplina()
        {
            CursoDisciplinas = new List<CursoDisciplina>();
        }
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }     
  
        public bool EhValido()
        {
            ValidationResult = new DisciplinaValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
