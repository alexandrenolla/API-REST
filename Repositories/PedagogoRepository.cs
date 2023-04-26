using RESTful_API.Context;
using RESTful_API.Models;
using RESTful_API.Repositories.Interfaces;

namespace RESTful_API.Repositories;

public class PedagogoRepository : IPedagogoRepository
{
    // Injeção de dependência do Contexto
    private readonly LabSchoolContext _context;
    public PedagogoRepository(LabSchoolContext context)
    {
        _context = context;
    }


    public List<PedagogoModel> ConsultarLista()
    {
        return _context.Pedagogos.ToList();
    }
}