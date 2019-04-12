using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Menu
{
    public class ModuloMenuModel
    {
        public string Nome { get; set; }
        public bool Autorizado { get; set; }
        public ICollection<PermissaoMenuModel> Permissoes { get; set; }
    }
}
