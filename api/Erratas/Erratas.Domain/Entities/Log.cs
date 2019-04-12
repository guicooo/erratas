using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Verbo { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Status { get; set; }
        public string Acao { get; set; }
        public string Controller { get; set; }
        public string Url { get; set; }
        public DateTime DataDeGravacao { get; set; }
        public string Retorno { get; set; }

    }
}
