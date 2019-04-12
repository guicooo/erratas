using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class ErrataConfig : EntityTypeConfiguration<Errata>
    {
        public ErrataConfig()
        {
            HasKey(x => x.Id);

            HasRequired(u => u.MotivoErrata)
                .WithMany()
                .HasForeignKey(u => u.MotivoErrataId);

            HasRequired(u => u.Disciplina)
                .WithMany()
                .HasForeignKey(u => u.DisciplinaId);            

            HasRequired(u => u.ResponsavelInsercao)
                .WithMany()
                .HasForeignKey(u => u.ResponsavelInsercaoId);

            HasRequired(u => u.ResponsavelRevisao)
                .WithMany()
                .HasForeignKey(u => u.ResponsavelRevisaoId);

            HasRequired(u => u.Instituto)
                .WithMany()
                .HasForeignKey(u => u.InstitutoId);

            HasRequired(u => u.Item)
                 .WithMany()
                 .HasForeignKey(u => u.ItemId);

            HasMany(x => x.ImagensErrata)
                .WithRequired()
                .HasForeignKey(ia => ia.ErratasId);

            HasRequired(u => u.Unidade)
                 .WithMany()
                 .HasForeignKey(u => u.UnidadeId);

            HasMany(c => c.ErrataCursos)
              .WithRequired()
              .HasForeignKey(c => c.ErrataId);

            Property(c => c.Descricao)
                .HasMaxLength(10000);

            Ignore(x => x.ValidationResult);
        }
    }
}

