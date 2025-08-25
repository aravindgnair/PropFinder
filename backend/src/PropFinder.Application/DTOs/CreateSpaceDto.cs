using System.ComponentModel.DataAnnotations;

namespace PropFinder.Application.DTOs;

public class CreateSpaceDto
{
    [Required, MaxLength(50)]
    public string Type { get; set; }

    [Required, Range(0, float.MaxValue)]
    public float Size { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}
