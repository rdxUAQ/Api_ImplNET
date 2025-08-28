using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required]
    public string? Name { get; set; } 
    [Required]
    public string? Description { get; set; } 
    [Range(0, int.MaxValue)]
    public int Stock { get; set; } 
}