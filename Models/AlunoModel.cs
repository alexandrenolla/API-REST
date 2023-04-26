namespace RESTful_API.Models;


public class AlunoModel : PessoaModel
{
    public string SituacaoMatricula { get; set; }
    public float NotaSeletivo { get; set; }
    public int AtendimentosPedagogicos { get; set; } = 0;
}