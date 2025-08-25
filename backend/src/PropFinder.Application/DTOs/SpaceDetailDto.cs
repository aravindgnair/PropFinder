namespace PropFinder.Application.DTOs;

public class SpaceDetailDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public float Size { get; set; }
    public string? Description { get; set; }
}
