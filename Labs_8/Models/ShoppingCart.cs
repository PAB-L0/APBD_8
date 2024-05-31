using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs_8.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Required]
    [ForeignKey("Account")]
    [Column("FK_account")]
    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;
    
    [Required]
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int ProductId { get; set; }

    public Product Product { get; set; } = null!;
    
    [Required]
    [Column("amount")]
    public int Amount { get; set; }
}