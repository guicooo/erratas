using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Cargos
{
    public class CargoPermissaoModuloModel
    {
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Modulo é obrigatório")]
        public Guid ModuloId { get; set; }

        [RegularExpression("^(?i)(true|false)$", ErrorMessage = "Valor inválido para o tipo boolean")]
        public bool Autorizado { get; set; }
    }
}
