using RESTful_API.Context;
using RESTful_API.Models;
using RESTful_API.Repositories.Interfaces;

namespace RESTful_API.Repositories;

public class AlunoRepository : IAlunoRepository
{
    // Injeção de dependência do Contexto
    private readonly LabSchoolContext _context;
    public AlunoRepository(LabSchoolContext context)
    {
        _context = context;
    }


    public void AtualizarSituacao(AlunoModel aluno)
    {
        _context.Alunos.Update(aluno);
        _context.SaveChanges();
    }

    public void Cadastrar(AlunoModel aluno)
    {
        _context.Alunos.Add(aluno);
        _context.SaveChanges();
    }

    public List<AlunoModel> ConsultarLista(string? situacaoMatricula)
    {   
        if(situacaoMatricula != null)
        {
            return _context.Alunos.Where(x => x.SituacaoMatricula == situacaoMatricula).ToList();
        }
        else
        {
            return _context.Alunos.ToList();
        }  
    }

    public AlunoModel ConsultarPorId(int codigo)
    {
        return _context.Alunos.FirstOrDefault(x => x.Codigo == codigo); // retorna nulo se não achar
    }

    public void Excluir(int codigo)
    {
        var aluno = ConsultarPorId(codigo);
        _context.Alunos.Remove(aluno);
        _context.SaveChanges();
    }

    public bool CPFUnico(string cpf)
    {
        return !_context.Alunos.Any(x => x.Cpf == cpf);
    }

}