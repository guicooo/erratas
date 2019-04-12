using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Erratas.Domain.Entities;
using Erratas.Application.Models.Modelo;

namespace Erratas.Application.Models
{
    public class UsuarioModel
    {       
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve possuir no mínimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Nome deve possuir no máximo 20 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "SobreNome é obrigatório")]
        [MinLength(3, ErrorMessage = "SobreNome deve possuir no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "SobreNome deve possuir no máximo 30 caracteres")]
        public string SobreNome { get; set; }              

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cargo é obrigatório")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Departamento é obrigatório")]
        public Guid DepartamentoId { get; set; }

        [RegularExpression("^(?i)(true|false)$", ErrorMessage = "Valor inválido para o tipo boolean")]
        public bool Ativo { get; set; }

        [Required]
        public List<string> Cursos { get; set; }
    }
}
