using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var produto = modelBuilder.Entity<Produto>();
        produto
            .Property(p => p.Preco)
            .HasPrecision(18, 2);

        produto
            .Property(p => p.Nome)
            .HasMaxLength(120)
            .IsRequired();


        var categoria = modelBuilder.Entity<Categoria>();
        categoria
            .Property(c => c.Descricao)
            .HasMaxLength(200)
            .IsRequired(false);

        categoria
            .Property(c => c.Nome)
            .HasMaxLength(80)
            .IsRequired();


        var cliente = modelBuilder.Entity<Cliente>();
        cliente
            .Property(c => c.Email)
            .IsRequired();

        cliente
            .Property(c => c.Idade)
            .IsRequired();

        cliente
            .Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();
    }

}