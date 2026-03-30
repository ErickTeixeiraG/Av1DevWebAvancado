using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 


namespace ProdutosApi;
[ApiController] 
[Route("api/[controller]")] 
public class ClientesController : ControllerBase{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAllAsync(){
        var clientes = await _context.Clientes.AsNoTracking().ToListAsync();
        return Ok(clientes);
    }

    [HttpGet("{id:int}", Name = "GetClienteByID")] 
    public async Task<ActionResult<Cliente>> GetByIdAsync(int id){
        var cliente = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null){
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CreateAsync(Cliente cliente){
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetClienteByID", new {id = cliente.Id}, cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Cliente Cliente){
        if(id != Cliente.Id) return BadRequest("Id do corpo diferente do parâmetro");

        var existe = await _context.Clientes.FindAsync(id);
        if(existe is null) return NotFound();

        //_context.Entry(Produto).State = EntityState.Modified; isso por algum motivo não rodou, algo com o findasync e o entry produto estarem buscando em duplicidade o item, então pesquisei campo a campo
        existe.Nome = Cliente.Nome;
        existe.Email = Cliente.Email;
        existe.Idade = Cliente.Idade;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id){
        var Cliente = await _context.Clientes.FindAsync(id);
        if(Cliente is null) return NotFound();

        _context.Clientes.Remove(Cliente);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}