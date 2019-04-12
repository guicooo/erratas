using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class CargoPermissao
    {
        public Guid Id { get; set; }
        public Guid CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public Guid PermissaoId { get; set; }
        public virtual Permissao Permissao { get; set; }
        public bool Autorizado { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }       
    }
}
