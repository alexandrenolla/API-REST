using FluentValidation;
using RESTful_API.Models;

namespace RESTful_API.Validator;

public class AlunoCadastroDtoValidator : AbstractValidator <AlunoModel>
{
    public AlunoCadastroDtoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.");
        RuleFor(x => x.Telefone).NotEmpty().NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.");
        RuleFor(x => x.DataNascimento).NotEmpty().NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.");
        RuleFor(x => x.Cpf).NotEmpty().NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.");
        RuleFor(x => x.SituacaoMatricula).NotEmpty().NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.").Must(Matricula).WithMessage("O campo SITUAÇÃO MATRÍCULA apenas aceita os seguintes valores: 'ATIVO', 'IRREGULAR', 'ATENDIMENTO', 'ATENDIMENTO_PEDAGOGICO' e 'INATIVO'.");
        RuleFor(x => x.NotaSeletivo).NotNull().WithMessage("Todos os campos de cadastro são de preenchimento obrigatório.").InclusiveBetween(0,10).WithMessage("O campo NOTA aceita valores entre 0 a 10.");
    }

    // VERIFICA SE A SITUAÇÃO DA MATRÍCULA ESTÁ COM VALORES ADMITIDOS
    private bool Matricula(string situacao)
    {
        if(situacao == "ATIVO" || situacao == "INATIVO" || situacao == "IRREGULAR"|| situacao == "ATENDIMENTO_PEDAGOGICO")
        {
            return true;
        }
        else
        {
            return false;
        }       
    }
}
