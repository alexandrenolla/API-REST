using Microsoft.AspNetCore.Mvc;
using RESTful_API.Repositories.Interfaces;
using RESTful_API.Dtos;
using RESTful_API.Models;

namespace RESTful_API.Controller;

[ApiController]
//[Route("[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorRepository _professorRepository;

    public ProfessorController(IProfessorRepository professorepository)
    {
        _professorRepository = professorepository;    
    }

    [HttpGet]
    [Route("api/professores")]
    public IActionResult Get()
    {
        var professores = _professorRepository.ConsultarLista();

        List<ProfessorSaidaDto> professorSaidaDto = new List<ProfessorSaidaDto>();
        foreach(var professor in professores)
        {
            var professorSaida = new ProfessorSaidaDto();
            professorSaida.Codigo = professor.Codigo;
            professorSaida.Nome = professor.Nome;
            professorSaida.Telefone = professor.Telefone;
            professorSaida.DataNascimento = professor.DataNascimento;
            professorSaida.Cpf = professor.Cpf;
            professorSaida.Formacao = professor.FormacaoAcademica;
            professorSaida.Experiencia = professor.ExperienciaDesenvolvimento;
            professorSaida.Estado = professor.Estado;

            professorSaidaDto.Add(professorSaida);
        }
        return Ok(professorSaidaDto);
    }
}