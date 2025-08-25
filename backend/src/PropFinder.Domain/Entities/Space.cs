namespace PropFinder.Domain.Entities;

public class Space
{
    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public string Type { get; set; } = string.Empty;
    public float Size { get; set; }
    public string? Description { get; set; }

    public Property Property { get; set; } = null!;
}
