using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Menu
{
    public class PermissaoMenuModel
    {
        public Guid Id { get; set; }
        public bool Autorizado { get; set; }
        public string Nome { get; set; }
    }
}
