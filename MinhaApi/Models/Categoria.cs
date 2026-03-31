using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Categoria{
    public int Id {get; set;}


    [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Nome deve ter no mínimo 3 até 80 caracteres.")]
    public string Nome {get; set;} = string.Empty;
    

    [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo 200 caracteres.")]
    public string? Descricao {get; set;}

}