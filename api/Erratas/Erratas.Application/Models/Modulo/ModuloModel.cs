using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Modulo
{
    public class ModuloModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<PermissaoModel> Permissoes { get; set; }
    }
}
