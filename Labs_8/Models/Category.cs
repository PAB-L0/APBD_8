using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs_8.Models;

[Table(("Categories"))]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int CategoryId { get; set; }

    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public IEnumerable<ProductsCategories> ProductsCategories { get; set; } = null!;
}