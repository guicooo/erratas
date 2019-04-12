using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class CargoConfig : EntityTypeConfiguration<Cargo>
    {
        public CargoConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired();
            Property(x => x.Ativo).IsRequired();
            Ignore(x => x.ValidationResult);

            HasMany(x => x.CargoPermissoes)
                .WithRequired()
                .HasForeignKey(cp => cp.CargoId);
        }
    }
}
