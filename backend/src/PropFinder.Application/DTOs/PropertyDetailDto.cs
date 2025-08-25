namespace PropFinder.Application.DTOs;

public class PropertyDetailDto
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public List<SpaceDetailDto> Spaces { get; set; } = [];
}
