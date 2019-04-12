using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models
{
    public class CargoModel
    {        
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "O campo nome precisa ter no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "O campo nome pode ter no máximo 30 caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
