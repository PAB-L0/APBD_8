using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs_8.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }

    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [Column("weight", TypeName = "decimal(5,2)")]
    public decimal Weight { get; set; }
    
    [Required]
    [Column("width", TypeName = "decimal(5,2)")]
    public decimal Width { get; set; }
    
    [Required]
    [Column("height", TypeName = "decimal(5,2)")]
    public decimal Height { get; set; }
    
    [Required]
    [Column("depth", TypeName = "decimal(5,2)")]
    public decimal Depth { get; set; }

    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public IEnumerable<ProductsCategories> ProductsCategories { get; set; } = null!;
}