using RESTful_API.Context;
using RESTful_API.Models;
using RESTful_API.Repositories.Interfaces;

namespace RESTful_API.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    // Injeção de dependência do Contexto
    private readonly LabSchoolContext _context;
    public ProfessorRepository(LabSchoolContext context)
    {
        _context = context;
    }


    public List<ProfessorModel> ConsultarLista()
    {
        return _context.Professores.ToList();
    }
}