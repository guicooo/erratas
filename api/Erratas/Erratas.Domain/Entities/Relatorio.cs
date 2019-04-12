using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Relatorio
    {
        public int Quantidade { get; set; }
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
