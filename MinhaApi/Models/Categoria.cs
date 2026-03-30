using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Categoria{
    public int Id {get; set;}


    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos de 3 caracteres")]
    [MaxLength(80, ErrorMessage = "O nome não pode ter mais de 80 caracteres")]
    public string Nome {get; set;} = string.Empty;
    

    [MaxLength(200, ErrorMessage = "A descrição não pode ter mais de 200 caracteres")]
    public string? Descricao {get; set;}

}