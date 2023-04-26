using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RESTful_API.Models;

namespace RESTful_API.Configuration;

public class AlunoConfiguration : IEntityTypeConfiguration<AlunoModel>
{
    public void Configure(EntityTypeBuilder<AlunoModel> builder)
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

        builder.Property(x => x.SituacaoMatricula)
        .IsRequired()
        .HasColumnName("Situação da Matrícula")
        .HasColumnOrder(6);

        builder.Property(x => x.NotaSeletivo)
        .IsRequired()
        .HasColumnName("Nota")
        .HasColumnOrder(7);

        builder.Property(x => x.AtendimentosPedagogicos)
        .HasDefaultValue(0)
        .HasColumnName("Qtd Atendimentos")
        .HasColumnOrder(8);

        builder.ToTable("ALUNOS");

        // Inserção dos dados iniciais
            builder.HasData(new[]
            {
                new AlunoModel() {Codigo = 1, Nome = "Bart Simpson", Telefone = "11-11111-1212", DataNascimento = new DateTime(2014, 10, 29), Cpf = "11839750073" , SituacaoMatricula = "IRREGULAR", NotaSeletivo = 3.5f , AtendimentosPedagogicos = 0 },
                new AlunoModel() {Codigo = 2, Nome = "Lisa Simpson", Telefone = "11-22222-2222", DataNascimento = new DateTime(2012, 10, 29), Cpf = "17158947076", SituacaoMatricula = "ATIVO", NotaSeletivo = 10, AtendimentosPedagogicos = 0 },
                new AlunoModel() {Codigo = 3, Nome = "Meggie Simpson", Telefone = "12-20002-2200" , DataNascimento = new DateTime(2019, 10, 29), Cpf = "63701210020", SituacaoMatricula = "ATIVO", NotaSeletivo = 9, AtendimentosPedagogicos = 0 },
                new AlunoModel() {Codigo = 4, Nome = "Milhouse Van Houten", Telefone = "11-33333-2222", DataNascimento = new DateTime(2014, 10, 29), Cpf = "30119137062", SituacaoMatricula = "ATIVO", NotaSeletivo = 8, AtendimentosPedagogicos = 0 },
                new AlunoModel() {Codigo = 5, Nome = "Nelson Muntz", Telefone = "11-44333-4444", DataNascimento = new DateTime(2007, 10, 29), Cpf = "95704094015", SituacaoMatricula = "INATIVO", NotaSeletivo = 2, AtendimentosPedagogicos = 0 }
            });

        
    }
}