using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class CursoConfig : EntityTypeConfiguration<Curso>
    {
        public CursoConfig()
        {
            HasMany(c => c.CursoDisciplinas)
                .WithRequired()
                .HasForeignKey(c => c.CursoId);

            HasMany(c => c.UsuarioCursos)
                .WithRequired()
                .HasForeignKey(c => c.CursoId);

            HasMany(c => c.ErrataCursos)
              .WithRequired()
              .HasForeignKey(c => c.CursoId);

            Ignore(x => x.ValidationResult);
        }
    }
}
