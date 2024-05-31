using Labs_8.Models;
using Microsoft.EntityFrameworkCore;

namespace Labs_8.Contexts;

public class MyDatabaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ProductsCategories> ProductsCategories { get; set; } = null!;
    
    protected MyDatabaseContext() {}

    public MyDatabaseContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(shoppingCart => new { shoppingCart.AccountId, shoppingCart.ProductId });

        modelBuilder.Entity<ProductsCategories>().HasKey(productsCategories =>
            new { productsCategories.ProductId, productsCategories.CategoryId });

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new()
            {
                RoleId = 1,
                Name = "User"
            },

            new()
            {
                RoleId = 2,
                Name = "Worker"
            }
        });

        modelBuilder.Entity<Account>().HasData(new List<Account>
        {
            new Account
            {
                AccountId = 1,
                RoleId = 1,
                FirstName = "Hugh",
                LastName = "Jass",
                Email = "hughjass@gmail.com"
            },
            
            new Account
            {
                AccountId = 2,
                RoleId = 2,
                FirstName = "Moe",
                LastName = "Lester",
                Email = "moelester@gmail.com",
                Phone = "123456789"
            }
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>
        {
            new Product
            {
                ProductId = 1,
                Name = "Apple",
                Weight = 0.25m,
                Width = 0.01m,
                Height = 0.01m,
                Depth = 0.01m
            },
            
            new Product
            {
                ProductId = 2,
                Name = "Banana",
                Weight = 0.25m,
                Width = 0.25m,
                Height = 0.05m,
                Depth = 0.05m
            }
        });

        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>
        {
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 1,
                Amount = 3
            },
            
            new ShoppingCart
            {
                AccountId = 2,
                ProductId = 2,
                Amount = 5
            }
        });

        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                Name = "BIO"
            },

            new Category
            {
                CategoryId = 2,
                Name = "Normal"
            }
        });

        modelBuilder.Entity<ProductsCategories>().HasData(new List<ProductsCategories>
        {
            new ProductsCategories
            {
                ProductId = 1,
                CategoryId = 1
            },
            
            new ProductsCategories
            {
                ProductId = 2,
                CategoryId = 2
            }
        });
    }
}