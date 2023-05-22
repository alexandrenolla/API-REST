namespace RESTful_API.Dtos;

public class PedagogoSaidaDto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public int Atendimentos { get; set; }
}