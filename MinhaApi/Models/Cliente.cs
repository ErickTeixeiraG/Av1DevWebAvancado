using System.ComponentModel.DataAnnotations;


namespace ProdutosApi;

public class Cliente{
    public int Id {get; set;}


    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter de 3 até 100 caracteres.")]
    public string Nome {get; set;} = string.Empty;
    

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email em formato inválido.")]
    public string Email {get; set;} = string.Empty;

    
    [Range(18, int.MaxValue, ErrorMessage = "Idade mínima é 18 anos.")]
    public int Idade {get; set;}

}