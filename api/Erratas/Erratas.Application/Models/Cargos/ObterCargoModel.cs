using Erratas.Application.Models.Modulo;
using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models
{
    public class ObterCargoModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ModuloModel> Modulos { get; set; }
    }
}
