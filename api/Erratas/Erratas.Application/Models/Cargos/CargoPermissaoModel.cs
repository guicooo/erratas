using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models
{
    public class CargoPermissaoModel
    {
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Permissao é obrigatória")]
        public Guid PermissaoId { get; set; }

        [RegularExpression("^(?i)(true|false)$", ErrorMessage = "Valor inválido para o tipo boolean")]
        public bool Autorizado { get; set; }
    }
}
