using System.ComponentModel.DataAnnotations;

namespace PropFinder.Application.DTOs;

public class CreatePropertyDto
{
    [Required, MaxLength(200)]
    public string Address { get; set; }

    [Required, MaxLength(50)]
    public string Type { get; set; }

    [Required, Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public List<SpaceDetailDto>? Spaces { get; set; }
}
