using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            Property(c => c.Nome).IsRequired();
            Property(c => c.SobreNome).IsRequired();
            Property(c => c.Email).IsRequired();            
         
            HasRequired(u => u.Cargo)
                .WithMany()
                .HasForeignKey(u => u.CargoId);

            HasRequired(u => u.Departamento)
                .WithMany()
                .HasForeignKey(u => u.DepartamentoId);

            HasMany(c => c.UsuarioCursos)
               .WithRequired()
               .HasForeignKey(c => c.UsuarioId);
            
            Ignore(u => u.ValidationResult);
            
        }
           
    }
}
