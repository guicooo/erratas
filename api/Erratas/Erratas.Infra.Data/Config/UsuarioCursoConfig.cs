using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class UsuarioCursoConfig : EntityTypeConfiguration<UsuarioCurso>
    {
        public UsuarioCursoConfig()
	    {
            // HasKey(c => new { c.CursoId, c.UsuarioId });
	    }
    }
}
