using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class PermissaoConfig : EntityTypeConfiguration<Permissao>
    {
        public PermissaoConfig()
        {
                HasMany(c => c.CargoPermissoes)
                   .WithRequired()
                   .HasForeignKey(c => c.PermissaoId);

                HasRequired(u => u.Modulo)
                 .WithMany()
                 .HasForeignKey(u => u.ModuloId);
        }
    }
}
