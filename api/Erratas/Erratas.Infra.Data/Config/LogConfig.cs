using Erratas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Config
{
    public class LogConfig : EntityTypeConfiguration<Log>
    {
        public LogConfig()
        {
            Property(c => c.Acao).IsRequired();
            Property(c => c.Controller).IsRequired();
            Property(c => c.DataDeGravacao).IsRequired();
            Property(c => c.Retorno).HasColumnType("nvarchar(max)");

            HasRequired(u => u.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId);
            
        }
    }
}
