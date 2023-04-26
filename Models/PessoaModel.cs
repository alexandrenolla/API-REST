namespace RESTful_API.Models;

public class PessoaModel
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
}