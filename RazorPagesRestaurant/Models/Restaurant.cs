using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesRestaurant.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location{ get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public string Order { get; set; } = string.Empty;
}