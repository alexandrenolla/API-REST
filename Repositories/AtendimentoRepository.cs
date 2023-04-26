using RESTful_API.Context;
using RESTful_API.Models;
using RESTful_API.Repositories.Interfaces;

namespace RESTful_API.Repositories;


public class AtendimentoRepository : IAtendimentoRepository
{
    // Injeção de dependência do Contexto
    private readonly LabSchoolContext _context;
    public AtendimentoRepository(LabSchoolContext context)
    {
        _context = context;
    }
    

    public void AtualizarAtendimentoPedagogo(PedagogoModel pedagogo)
    {
        _context.Pedagogos.Update(pedagogo);
        _context.SaveChanges();
    }

    public void AtualizarAtendimentoAluno(AlunoModel aluno)
    {
        _context.Alunos.Update(aluno);
        _context.SaveChanges();
    }



    public PedagogoModel ConsultarIdPedagogo(int codigo)
    {
        return _context.Pedagogos.FirstOrDefault(x => x.Codigo == codigo); 
    }
    public AlunoModel ConsultarIdAluno(int codigo)
    {
        return _context.Alunos.FirstOrDefault(x => x.Codigo == codigo); 
    }
}