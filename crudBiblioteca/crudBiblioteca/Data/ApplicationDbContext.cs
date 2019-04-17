using System;
using System.Collections.Generic;
using System.Text;
using crudBiblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crudBiblioteca.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Acervo> Acervos { get; set; }
        public DbSet<Leitor> Leitores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acervo>().HasData(new Acervo { Id = 1, Nome = "Acervo" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
