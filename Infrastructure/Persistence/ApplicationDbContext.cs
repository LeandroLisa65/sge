using Application.Common.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasDefaultSchema("dbo");
    }
    
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Cost> Costs { get; set; } = default!;
    public DbSet<Permission> Permissions { get; set; } = default!;
    public DbSet<Price> Prices { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Provider> Providers { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<Sell> Sells { get; set; } = default!;
    public DbSet<Table> Tables { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Payment> Payments { get; set; } = default!;
    public DbSet<SellDetail> SellDetails { get; set; } = default!;
    public DbSet<Store> Stores { get; set; } = default!;
    public DbSet<Company> Companies { get; set; } = default!;
    public DbSet<ProductCostHistory> ProductCostHistories { get; set; }
    public DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
}