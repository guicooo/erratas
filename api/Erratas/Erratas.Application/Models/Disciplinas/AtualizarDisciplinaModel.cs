using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Disciplinas
{
    public class AtualizarDisciplinaModel
    {
        [Required]
        public string CodigoModelo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public ICollection<string> Cursos { get; set; }
    }
}
