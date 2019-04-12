using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models.Menu
{
    public class MenuModel
    {
        public ICollection<ModuloMenuModel> Modulos { get; set; }
    }
}
