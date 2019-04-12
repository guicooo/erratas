using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class CargoPermissaoConfig : EntityTypeConfiguration<CargoPermissao>
    {
        public CargoPermissaoConfig()
        {
            Ignore(x => x.ValidationResult);
            // HasKey(c => new { c.CargoId, c.PermissaoId });
        }
    }
}
