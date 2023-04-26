using RESTful_API.Models;

namespace RESTful_API.Repositories.Interfaces;

public  interface IProfessorRepository
{
    List<ProfessorModel> ConsultarLista();
}