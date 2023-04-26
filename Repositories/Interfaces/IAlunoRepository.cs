using RESTful_API.Models;

namespace RESTful_API.Repositories.Interfaces;

public interface IAlunoRepository
{
    void Cadastrar(AlunoModel aluno);

    void AtualizarSituacao(AlunoModel aluno);

    List<AlunoModel> ConsultarLista(string? situacaoMatricula);

    AlunoModel ConsultarPorId(int codigo);

    void Excluir(int codigo);

    bool CPFUnico(string cpf);
}