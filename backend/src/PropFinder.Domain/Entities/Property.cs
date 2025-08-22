namespace PropFinder.Domain.Entities;

public class Property
{
    public Guid Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public ICollection<Space> Spaces { get; set; } = new List<Space>();
}
