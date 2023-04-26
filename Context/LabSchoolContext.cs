using Microsoft.EntityFrameworkCore;
using RESTful_API.Configuration;
using RESTful_API.Models;

namespace RESTful_API.Context;

public class LabSchoolContext : DbContext
{
    public DbSet<AlunoModel> Alunos { get; set; }
    public DbSet<ProfessorModel> Professores { get; set; }
    public DbSet<PedagogoModel> Pedagogos { get; set; }


    public LabSchoolContext(DbContextOptions<LabSchoolContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlunoConfiguration());

        modelBuilder.ApplyConfiguration(new ProfessorConfiguration());

        modelBuilder.ApplyConfiguration(new PedagogoConfiguration());

    }
}