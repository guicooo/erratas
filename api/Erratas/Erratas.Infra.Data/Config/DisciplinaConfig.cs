using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class DisciplinaConfig : EntityTypeConfiguration<Disciplina>
    {
        public DisciplinaConfig()
        {
            HasMany(c => c.CursoDisciplinas)
                .WithRequired()
                .HasForeignKey(c => c.DisciplinaId);

            Ignore(c => c.ValidationResult);
        }
    }
}
