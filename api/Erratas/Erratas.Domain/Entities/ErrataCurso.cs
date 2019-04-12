using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class ErrataCurso
    {
        public Guid Id { get; set; }
        public Guid ErrataId { get; set; }
        public Errata Errata { get; set; }
        public string CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
