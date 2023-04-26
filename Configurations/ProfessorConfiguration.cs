using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTful_API.Models;

namespace RESTful_API.Configuration;

public class ProfessorConfiguration : IEntityTypeConfiguration<ProfessorModel>
{
    public void Configure(EntityTypeBuilder<ProfessorModel> builder)
    {
        builder.HasKey(x => x.Codigo);

        builder.Property(x => x.Codigo)
        .HasColumnName("Código")
        .HasColumnOrder(1);

        builder.Property(x => x.Nome)
        .IsRequired()
        .HasColumnName("Nome")
        .HasColumnOrder(2);

        builder.Property(x => x.Telefone)
        .IsRequired()
        .HasColumnName("Telefone")
        .HasColumnOrder(3);

        builder.Property(x => x.DataNascimento)
        .IsRequired()
        .HasColumnName("Data de nascimento")
        .HasColumnOrder(4);

        builder.Property(x => x.Cpf)
        .IsRequired()
        .HasColumnName("Cpf")
        .HasColumnOrder(5);

        builder.Property(x => x.Estado)
        .IsRequired()
        .HasColumnName("Estado")
        .HasColumnOrder(6);

        builder.Property(x => x.ExperienciaDesenvolvimento)
        .IsRequired()
        .HasColumnName("Experiência")
        .HasColumnOrder(7);

        builder.Property(x => x.FormacaoAcademica)
        .IsRequired()
        .HasColumnName("Formação Acadêmica")
        .HasColumnOrder(8);

        builder.ToTable("PROFESSORES");

        // Inserção dos dados iniciais
        builder.HasData(new[]
        {
            new ProfessorModel() {Codigo = 1, Nome = "Walter White", Telefone = "14-22998-1882", DataNascimento = new DateTime(1982, 10, 30), Cpf = "40539019011", Estado = "ATIVO", ExperienciaDesenvolvimento = "FULL_STACK", FormacaoAcademica = "MESTRADO"},
            new ProfessorModel() {Codigo = 2, Nome = "Jesse Pinkman", Telefone = "44-11111-1992" , DataNascimento = new DateTime(1997, 10, 30), Cpf = "96107295097", Estado = "ATIVO", ExperienciaDesenvolvimento = "BACK_END", FormacaoAcademica = "GRADUACAO_INCOMPLETA"},
            new ProfessorModel() {Codigo = 3, Nome = "Hank Schrader", Telefone = "44-11111-1002", DataNascimento = new DateTime(1984, 10, 30), Cpf = "70685977005", Estado = "ATIVO", ExperienciaDesenvolvimento = "FULL_STACK", FormacaoAcademica = "MESTRADO"},
            new ProfessorModel() {Codigo = 4, Nome = "Gustavo Fring", Telefone = "44-11001-1002", DataNascimento = new DateTime(1977, 10, 30), Cpf = "57408927085", Estado = "INATIVO", ExperienciaDesenvolvimento = "FRONT_END", FormacaoAcademica = "GRADUACAO_INCOMPLETA"},
            new ProfessorModel() {Codigo = 5, Nome = "Saul Goodman", Telefone = "44-11998-1882", DataNascimento = new DateTime(1980, 10, 30), Cpf = "86940162062", Estado = "ATIVO", ExperienciaDesenvolvimento = "FULL_STACK", FormacaoAcademica = "MESTRADO"}
        });
    }
}