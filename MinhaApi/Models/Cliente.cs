using System.ComponentModel.DataAnnotations;


namespace ProdutosApi;

public class Cliente{
    public int Id {get; set;}


    [Required(ErrorMessage = "Nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos de 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
    public string Nome {get; set;} = string.Empty;
    

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email em formato inválido.")]
    public string Email {get; set;} = string.Empty;

    
    [Range(18, 999999999, ErrorMessage = "Idade mínima é 18 anos.")]
    public int Idade {get; set;}

}