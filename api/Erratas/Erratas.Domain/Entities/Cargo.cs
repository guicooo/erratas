using Erratas.Domain.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            CargoPermissoes = new List<CargoPermissao>();
        }
     
        public Guid Id { get; set; }
        public string Nome { get; set; }        
        public bool Ativo { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }
        public virtual ICollection<CargoPermissao> CargoPermissoes { get; set; }        
        public bool EhValido()
        {
            ValidationResult = new CargoValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
