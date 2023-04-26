using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTful_API.Models;

namespace RESTful_API.Configuration;

public class PedagogoConfiguration : IEntityTypeConfiguration<PedagogoModel>
{
    public void Configure(EntityTypeBuilder<PedagogoModel> builder)
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

        builder.Property(x => x.AtendimentosPedagogicos)
        .HasDefaultValue(0)
        .HasColumnName("Qtd Atendimentos")
        .HasColumnOrder(6);

        builder.ToTable("PEDAGOGOS");

        // Inserção dos dados iniciais
        builder.HasData(new[]
        {
            new PedagogoModel() {Codigo = 1, Nome = "John Snow", Telefone = "11-67333-4454", DataNascimento = new DateTime(2000, 10, 30), Cpf = "62316840086",AtendimentosPedagogicos = 0 },
            new PedagogoModel() {Codigo = 2, Nome = "Sansa Stark", Telefone =  "22-22333-4454", DataNascimento = new DateTime(2004, 10, 30), Cpf = "49850253053", AtendimentosPedagogicos = 0 },
            new PedagogoModel() {Codigo = 3, Nome = "Tyrion Lannister", Telefone = "33-77333-4454" , DataNascimento = new DateTime(1990, 10, 30), Cpf = "39125106015", AtendimentosPedagogicos = 0 },
            new PedagogoModel() {Codigo = 4, Nome = "Sandor Clegane", Telefone = "11-33333-2222", DataNascimento = new DateTime(1995, 10, 30), Cpf = "89089606009", AtendimentosPedagogicos = 0 }
        });
    }
}