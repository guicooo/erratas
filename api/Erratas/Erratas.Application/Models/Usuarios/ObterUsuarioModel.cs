using Erratas.Application.Models.Cursos;
using Erratas.Application.Models.Menu;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Usuarios
{
    public class ObterUsuarioModel
    {
        public ObterUsuarioModel()
        {           
            Cursos = new List<CursoModel>();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public CargoModel Cargo { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<CursoModel> Cursos { get; set; }        
      
    }
}
