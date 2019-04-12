using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Application.Models
{
    public class PermissaoModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Abreviacao { get; set; }
        public bool Autorizado { get; set; }
    }
}
