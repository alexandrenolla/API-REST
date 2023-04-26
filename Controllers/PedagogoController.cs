using Microsoft.AspNetCore.Mvc;
using RESTful_API.Repositories.Interfaces;
using RESTful_API.Dtos;

namespace RESTful_API.Controller;

[ApiController]
//[Route("[controller]")]

public class PedagogoController : ControllerBase
{
    private readonly IPedagogoRepository _pedagogoRepository;

    public PedagogoController(IPedagogoRepository pedagogorepository)
    {
        _pedagogoRepository = pedagogorepository;    
    }

    [HttpGet]
    [Route("api/pedagogos")]
    public IActionResult Get()
    {
        var pedagogos = _pedagogoRepository.ConsultarLista();

        List<PedagogoSaidaDto> pedagogoSaidaDto = new List<PedagogoSaidaDto>();
        foreach(var pedagogo in pedagogos)
        {
            var pedagogoSaida = new PedagogoSaidaDto();
            pedagogoSaida.Codigo = pedagogo.Codigo;
            pedagogoSaida.Nome = pedagogo.Nome;
            pedagogoSaida.Telefone = pedagogo.Telefone;
            pedagogoSaida.DataNascimento = pedagogo.DataNascimento;
            pedagogoSaida.Cpf = pedagogo.Cpf;
            pedagogoSaida.Atendimentos  = pedagogo.AtendimentosPedagogicos;

            pedagogoSaidaDto.Add(pedagogoSaida);
        }
        return Ok(pedagogoSaidaDto);
    }
}