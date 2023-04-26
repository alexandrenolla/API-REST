using Microsoft.AspNetCore.Mvc;
using RESTful_API.Dtos;
using RESTful_API.Models;
using RESTful_API.Repositories.Interfaces;
using RESTful_API.Validator;

namespace RESTful_API.Controller;

[ApiController]
//[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunosController(IAlunoRepository alunorepository)
    {
        _alunoRepository = alunorepository;    
    }


    [HttpGet]
    [Route("api/alunos")]
    public IActionResult Get(string? situacao)
    {   
        if(!string.IsNullOrEmpty(situacao) && (situacao != "ATIVO" && situacao != "IRREGULAR" && situacao != "INATIVO" && situacao != "ATENDIMENTO_PEDAGOGICO"))
        {
          return BadRequest("Valor informado inválido. Tente novamente com um dos valores válidos: ATIVO, INATIVO, IRREGULAR ou ATENDIMENTO_PEDAGOGICO");  
        }

        var alunos = _alunoRepository.ConsultarLista(situacao);

        if(alunos.Count() == 0)
        {
            return NotFound("Entre os alunos cadastrados, no momento, não há nenhum com a situação de matrícula informada. Tente novamente com uma situação de matrícula existente."); 
        }
        else
        {
            List<AlunoSaidaDto> alunosSaidaDto = new List<AlunoSaidaDto>();
            foreach(var aluno in alunos)
            {
                var alunoSaida = new AlunoSaidaDto();
                alunoSaida.Codigo = aluno.Codigo;
                alunoSaida.Nome = aluno.Nome;
                alunoSaida.Telefone = aluno.Telefone;
                alunoSaida.DataNascimento = aluno.DataNascimento;
                alunoSaida.Cpf = aluno.Cpf;
                alunoSaida.Situacao = aluno.SituacaoMatricula;
                alunoSaida.Nota = aluno.NotaSeletivo;
                alunoSaida.Atendimentos = aluno.AtendimentosPedagogicos;
                
                alunosSaidaDto.Add(alunoSaida);
            }
            return Ok(alunosSaidaDto);
        }
    }

    [HttpGet]
    [Route("api/alunos/{codigo}")]
    public IActionResult GetCodigo(int codigo)
    {
        var aluno = _alunoRepository.ConsultarPorId(codigo);
        if(aluno == null)
        {
            return NotFound("Entre os alunos cadastrados, no momento, não há nenhum com o código informado. Tente novamente com um código existente.");
        }
        else
        {   
            var alunoSaida = new AlunoSaidaDto();
            alunoSaida.Codigo = aluno.Codigo;
            alunoSaida.Nome = aluno.Nome;
            alunoSaida.Telefone = aluno.Telefone;
            alunoSaida.DataNascimento = aluno.DataNascimento;
            alunoSaida.Cpf = aluno.Cpf;
            alunoSaida.Situacao = aluno.SituacaoMatricula;
            alunoSaida.Nota = aluno.NotaSeletivo;
            alunoSaida.Atendimentos = aluno.AtendimentosPedagogicos;

            return Ok(alunoSaida);
        }   
    }


    [HttpPost]
    [Route("api/alunos")]
    public async Task<IActionResult> Create([FromBody] AlunoCadastroDto alunoDto)
    {   
        var aluno = new AlunoModel();
        aluno.Nome = alunoDto.Nome;
        aluno.Telefone = alunoDto.Telefone;
        aluno.DataNascimento = alunoDto.DataNascimento;
        aluno.Cpf = alunoDto.Cpf;
        aluno.SituacaoMatricula = alunoDto.Situacao;
        aluno.NotaSeletivo = alunoDto.Nota;

        var validacaoAluno = new AlunoCadastroDtoValidator();
        var resultadoValidacao = validacaoAluno.Validate(aluno);

        // Verificação se as regras do Validator foram cumpridas no novo objeto.
        if(resultadoValidacao.IsValid == false)
        {
            return StatusCode(StatusCodes.Status400BadRequest, resultadoValidacao.Errors);
        }
        else if(_alunoRepository.CPFUnico(aluno.Cpf) == false)
        {
            return Conflict("Este CPF já encontra-se registrado no banco de dados.");
        }
        else
        {
            _alunoRepository.Cadastrar(aluno);
            
            var novoAluno = new AlunoSaidaDto();
            novoAluno.Codigo = aluno.Codigo;
            novoAluno.Nome = aluno.Nome;
            novoAluno.Telefone = aluno.Telefone;
            novoAluno.DataNascimento = aluno.DataNascimento;
            novoAluno.Cpf = aluno.Cpf;
            novoAluno.Situacao = aluno.SituacaoMatricula;
            novoAluno.Nota = aluno.NotaSeletivo;
            novoAluno.Atendimentos = aluno.AtendimentosPedagogicos;

            return CreatedAtAction(nameof(AlunosController.GetCodigo), new {codigo = aluno.Codigo}, novoAluno);
        } 
    }

    [HttpPut]
    [Route("api/alunos/{codigo}")]
    public async Task<IActionResult> Update(int codigo, [FromBody] AlunoAlteracaoMatriculaDto alunoDto)
    {
        var aluno = _alunoRepository.ConsultarPorId(codigo);
        if (aluno == null)
        {
            return NotFound("Entre os alunos cadastrados, no momento, não há nenhum com o código informado. Tente novamente com um código existente.");
        }
        else if (!string.IsNullOrEmpty(alunoDto.Situacao) && (alunoDto.Situacao != "ATIVO" && alunoDto.Situacao != "IRREGULAR" && alunoDto.Situacao != "INATIVO" && alunoDto.Situacao != "ATENDIMENTO_PEDAGOGICO"))
        {  
            return BadRequest("Valor informado inválido. Tente novamente com um dos valores válidos: ATIVO, INATIVO, IRREGULAR ou ATENDIMENTO_PEDAGOGICO");  
        }
        else if (string.IsNullOrEmpty(alunoDto.Situacao))
        {
            return BadRequest("Campo de preenchimento obrigatório."); 
        }
        else
        {   
            aluno.SituacaoMatricula = alunoDto.Situacao;
            
            var alunoSaida = new AlunoSaidaDto();
            alunoSaida.Codigo = aluno.Codigo;
            alunoSaida.Nome = aluno.Nome;
            alunoSaida.Telefone = aluno.Telefone;
            alunoSaida.DataNascimento = aluno.DataNascimento;
            alunoSaida.Cpf = aluno.Cpf;
            alunoSaida.Situacao = aluno.SituacaoMatricula;
            alunoSaida.Nota = aluno.NotaSeletivo;
            alunoSaida.Atendimentos = aluno.AtendimentosPedagogicos;

            _alunoRepository.AtualizarSituacao(aluno);
        
            return Ok(alunoSaida);
        }
    }

    [HttpDelete]
    [Route("api/alunos/{codigo}")]
    public async Task<IActionResult> Delete(int codigo)
    {
        var aluno = _alunoRepository.ConsultarPorId(codigo);
        if(aluno == null)
        {
            return NotFound("Entre os alunos cadastrados, no momento, não há nenhum com o código informado. Tente novamente com um código existente.");
        }
        else
        {
            _alunoRepository.Excluir(codigo);
            return NoContent();
        }
    }
}

