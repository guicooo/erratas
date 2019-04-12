using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Abreviacao { get; set; }
        public virtual ICollection<CargoPermissao> CargoPermissoes { get; set; }
        public Guid ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
