using System;
using System.Data.Entity;
using LoginAuthorize.Models;

namespace LoginAuthorize.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext() : base("default")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().HasKey(model => model.Id);
            modelBuilder.Entity<Usuario>().Property(model => model.Nome).HasColumnName("nome").HasColumnType("varchar(80)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(model => model.Username).HasColumnName("username").HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(model => model.Senha).HasColumnName("password").HasColumnType("varchar(30)").IsRequired();
        }
    }
}