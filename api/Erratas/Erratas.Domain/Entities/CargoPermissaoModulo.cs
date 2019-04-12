using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class CargoPermissaoModulo
    {
        public Guid CargoId { get; set; }  
        public Guid ModuloId { get; set; }        
        public bool Autorizado { get; set; }
        public virtual ValidationResult ValidationResult { get; set; }       
    }
}
