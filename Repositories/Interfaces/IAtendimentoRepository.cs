using RESTful_API.Models;

namespace RESTful_API.Repositories.Interfaces;

public interface IAtendimentoRepository
{
    public void AtualizarAtendimentoPedagogo(PedagogoModel pedagogo);
    public PedagogoModel ConsultarIdPedagogo(int codigo);
    public void AtualizarAtendimentoAluno(AlunoModel aluno);
    public AlunoModel ConsultarIdAluno(int codigo);
    
}






