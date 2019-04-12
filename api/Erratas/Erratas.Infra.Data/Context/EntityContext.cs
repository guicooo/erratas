using Erratas.Domain.Entities;
using Erratas.Infra.Data.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Infra.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<CargoPermissao> CargoPermissoes { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<UsuarioCurso> UsuarioCurso { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Instituto> Instituto { get; set; }
        public DbSet<MotivoErrata> MotivoErrata { get; set; }
        public DbSet<ImagemErrata> ImagemErrata { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<Item> Item { get; set; }        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Where(p => p.Name != "Retorno")
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Properties<string>()
                .Where(p => p.Name == "Descricao")
                .Configure(p => p.HasColumnType("varchar(max)"));

            modelBuilder.Configurations.Add<Usuario>(new UsuarioConfig());
            modelBuilder.Configurations.Add<Cargo>(new CargoConfig());
            modelBuilder.Configurations.Add<CargoPermissao>(new CargoPermissaoConfig());
            modelBuilder.Configurations.Add<Log>(new LogConfig());
            modelBuilder.Configurations.Add<UsuarioCurso>(new UsuarioCursoConfig());
            modelBuilder.Configurations.Add<Curso>(new CursoConfig());
            modelBuilder.Configurations.Add<Disciplina>(new DisciplinaConfig());
            modelBuilder.Configurations.Add<Errata>(new ErrataConfig());
            modelBuilder.Configurations.Add<ImagemErrata>(new ImagemErrataConfig());
        
            Database.SetInitializer<EntityContext>(null);
            
            base.OnModelCreating(modelBuilder);
        }       
    }
}
