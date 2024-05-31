using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs_8.Models;

[Table(("Products_Categories"))]
public class ProductsCategories
{
    [Required]
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;
    
    [Required]
    [ForeignKey("Category")]
    [Column("FK_category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}