using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 


namespace ProdutosApi;
[ApiController] 
[Route("api/[ontroller]")] 
public class ProdutosController : ControllerBase{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context){
        _context = context;
    }

    [HttpGet]   
    public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync(){
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "GetProdByID")] 
    public async Task<ActionResult<Produto>> GetByIdAsync(int id){
        var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (produto is null){
            return NotFound(); // Erro 404
        }

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CreateAsync(Produto produto){
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetProdByID", new {id = produto.Id}, produto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Produto Produto){
        if(id != Produto.Id) return BadRequest("Id do corpo diferente do parâmetro");

        var existe = await _context.Produtos.FindAsync(id);
        if(existe is null) return NotFound();

        _context.Entry(Produto).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var Produto = await _context.Produtos.FindAsync(id);
        if(Produto is null) return NotFound();

        _context.Produtos.Remove(Produto);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204
    }
}