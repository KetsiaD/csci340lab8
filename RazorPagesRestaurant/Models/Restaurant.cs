using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesRestaurant.Models;

public class Restaurant
{
    public int Id { get; set; }
    [StringLength(80, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }
    [StringLength(80, MinimumLength = 3)]
    [Required]
    public string? Location{ get; set; }
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    [StringLength(80, MinimumLength = 3)]
    [Required]
    public string Order { get; set; } = string.Empty;
}