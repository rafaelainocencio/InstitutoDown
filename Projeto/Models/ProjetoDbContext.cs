using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class ProjetoDbContext : DbContext
     {
        public ProjetoDbContext (DbContextOptions<ProjetoDbContext> options) :
      base(options)
        { }
        public DbSet<Candidatura> Candidaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}