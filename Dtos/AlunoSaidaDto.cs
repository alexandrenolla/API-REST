namespace RESTful_API.Dtos;

public class AlunoSaidaDto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public string Situacao { get; set; }
    public float Nota { get; set; }
    public int Atendimentos { get; set; }
}