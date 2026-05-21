using GlobalSolution2._0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalSolution2._0.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<EmpresaModel> Empresa { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<VagaModel> Vaga { get; set; }
        public DbSet<CandidaturaModel> Candidatura { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
