using Microsoft.AspNetCore.Mvc;
using RESTful_API.Dtos;
using RESTful_API.Repositories.Interfaces;

namespace RESTful_API.Controller;

[ApiController]
//[Route("[controller]")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoRepository _atendimentoRepository;

    public AtendimentoController(IAtendimentoRepository atendimentorepository)
    {
        _atendimentoRepository = atendimentorepository;    
    }

    [HttpPut]
    [Route("api/atendimentos")]
    public IActionResult Update([FromBody] AtendimentoPedagogicoDto atendimentoDto)
    {   
        
        var pedagogo = _atendimentoRepository.ConsultarIdPedagogo(atendimentoDto.CodigoPedagogo);
        var aluno = _atendimentoRepository.ConsultarIdAluno(atendimentoDto.CodigoAluno);
        
        if (pedagogo == null || aluno == null)
        {
            return NotFound("Entre os alunos e/ou pedagogos cadastrados, no momento, não há com nenhum com um ou ambos os códigos informados. Tente novamente com códigos existentes.");
        }
        else
        {   
            pedagogo.AtendimentosPedagogicos = pedagogo.AtendimentosPedagogicos + 1;
            aluno.AtendimentosPedagogicos = aluno.AtendimentosPedagogicos + 1;

            _atendimentoRepository.AtualizarAtendimentoPedagogo(pedagogo);
            _atendimentoRepository.AtualizarAtendimentoAluno(aluno);

            var pedagogoSaida = new PedagogoSaidaDto();
            pedagogoSaida.Codigo = pedagogo.Codigo;
            pedagogoSaida.Nome = pedagogo.Nome;
            pedagogoSaida.Telefone = pedagogo.Telefone;
            pedagogoSaida.DataNascimento = pedagogo.DataNascimento;
            pedagogoSaida.Cpf = pedagogo.Cpf;
            pedagogoSaida.Atendimentos = pedagogo.AtendimentosPedagogicos;

            var alunoSaida = new AlunoSaidaDto();
            alunoSaida.Codigo = aluno.Codigo;
            alunoSaida.Nome = aluno.Nome;
            alunoSaida.Telefone = aluno.Telefone;
            alunoSaida.DataNascimento = aluno.DataNascimento;
            alunoSaida.Cpf = aluno.Cpf;
            alunoSaida.Situacao = aluno.SituacaoMatricula;
            alunoSaida.Nota = aluno.NotaSeletivo;
            alunoSaida.Atendimentos = aluno.AtendimentosPedagogicos;

            return Ok(new {alunoSaida, pedagogoSaida});
        }
    }
        
}