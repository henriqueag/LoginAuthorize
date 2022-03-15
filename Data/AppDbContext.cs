using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using LoginAuthorize.Models;
using System.IO;

namespace LoginAuthorize.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext() : base("default")
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                using (var sw = new StreamWriter(@"C:\Projetos\LoginAuthorize\log.txt", true))
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        sw.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sw.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().HasKey(model => model.Id);
            modelBuilder.Entity<Usuario>().Property(model => model.Nome).HasColumnType("nvarchar").HasMaxLength(80).HasColumnName("nome").IsRequired();
            modelBuilder.Entity<Usuario>().Property(model => model.Username).HasColumnType("nvarchar").HasMaxLength(30).HasColumnName("username").IsRequired();
            modelBuilder.Entity<Usuario>().Property(model => model.Senha).HasColumnType("nvarchar").HasMaxLength(100).HasColumnName("password").IsRequired();
        }
    }
}