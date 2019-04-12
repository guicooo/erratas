using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class ImagemErrataConfig : EntityTypeConfiguration<ImagemErrata>
    {
        public ImagemErrataConfig()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Erratas)
                .WithMany()
                .HasForeignKey(x => x.ErratasId);

            Property(x => x.CaminhoImagem).HasMaxLength(600);
           
        }
    }
}
