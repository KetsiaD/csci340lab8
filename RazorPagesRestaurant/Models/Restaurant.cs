using System.ComponentModel.DataAnnotations;

namespace RazorPagesRestaurant.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location{ get; set; }
    public decimal Price { get; set; }
}