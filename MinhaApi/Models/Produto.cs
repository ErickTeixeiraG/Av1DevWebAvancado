using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Produto{
    public int Id {get; set;}


    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(120, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 120 caracteres.")]
    public string Nome {get; set;} = string.Empty;
    

    // encontrei o comando MinimumIsExclusive = true na internet e utilizei como solução para impedir um preço = 0 mas liberar com centavos
    [Range(typeof(decimal),"0", "99999999999,99", MinimumIsExclusive = true ,ErrorMessage = "Preço deve ser maior que 0")]
    public decimal Preco {get; set;}
    

    [Range(0, 999999999, ErrorMessage = "Estoque não pode ser negativo")]
    public int Estoque {get; set;}

}