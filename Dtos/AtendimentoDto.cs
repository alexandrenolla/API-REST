using System.ComponentModel.DataAnnotations;

namespace RESTful_API.Dtos;

public class AtendimentoPedagogicoDto
{   //Data Annotation
    [Required()]
    public int CodigoAluno { get; set; }
    [Required()]
    public int CodigoPedagogo { get; set; }
    
}
