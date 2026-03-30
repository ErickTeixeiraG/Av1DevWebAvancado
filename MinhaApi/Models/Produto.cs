using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Produto{
    public int Id {get; set;}


    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos de 3 caracteres")]
    [MaxLength(120, ErrorMessage = "O nome não pode ter mais de 120 caracteres")]
    public string Nome {get; set;} = string.Empty;
    

    // encontrei o comando MinimumIsExclusive = true na internet e utilizei como solução para impedir um preço = 0 mas liberar com centavos
    [Range(typeof(decimal),"0", "99999999999,99", MinimumIsExclusive = true ,ErrorMessage = "O Preço deve ser maior que 0")]
    public decimal Preco {get; set;}
    

    [Range(0, 999999999, ErrorMessage = "O estoque não pode ser negativo")]
    public int Estoque {get; set;}

}