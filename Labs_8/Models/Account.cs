using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labs_8.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    
    [Required]
    [ForeignKey("Role")]
    [Column("FK_role")]
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;

    [Required]
    [Column("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [Column("email")]
    [MaxLength(80)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [MaxLength(9)]
    public string? Phone { get; set; } = null!;

    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; } = null!;
}