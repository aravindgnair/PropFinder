using PropFinder.Domain.Entities;
using PropFinder.Infrastructure.Persistence;

namespace PropFinder.Infrastructure.Seed;

public static class SeedData
{
    public static void Initialize(PropFinderDbContext context)
    {
        if (context.Properties.Any())
        {
            return;
        }

        var properties = GetMockProperties();
        context.Properties.AddRange(properties);
        context.SaveChanges();
    }

    private static IEnumerable<Property> GetMockProperties()
    {
        var properties = new List<Property>
        {
            new()
            {
                Address = "123 Main St, Springfield",
                Type = "House",
                Price = 250000,
                Description = "Beautiful 3-bedroom house",
                Spaces =
                [
                    new Space { Type = "Bedroom", Size = 150, Description = "Master bedroom" },
                    new Space { Type = "Kitchen", Size = 100, Description = "Modern kitchen" },
                    new Space { Type = "Living Room", Size = 200, Description = "Spacious living room" }
                ]
            },
            new()
            {
                Address = "456 Oak Ave, Metropolis",
                Type = "Apartment",
                Price = 1200,
                Description = "2-bedroom rental apartment",
                Spaces =
                [
                    new Space { Type = "Bedroom", Size = 120 },
                    new Space { Type = "Bathroom", Size = 60 },
                    new Space { Type = "Kitchen", Size = 80 }
                ]
            },
            new()
            {
                Address = "742 Evergreen Terrace, Springfield, IL",
                Type = "House",
                Price = 320000,
                Description = "Charming 3-bedroom home in a quiet neighborhood",
                Spaces =
                [
                    new Space { Type = "Bedroom", Size = 140, Description = "Master bedroom with ensuite" },
                    new Space { Type = "Kitchen", Size = 110, Description = "Renovated kitchen with granite countertops" },
                    new Space { Type = "Garage", Size = 250, Description = "Attached 2-car garage" }
                ]
            },
            new()
            {
                Address = "1600 Ocean Ave, Santa Monica, CA",
                Type = "Apartment",
                Price = 850000,
                Description = "Luxury beachfront condo with panoramic views",
                Spaces =
                [
                    new Space { Type = "Living Room", Size = 180, Description = "Open-concept living area with ocean view" },
                    new Space { Type = "Bedroom", Size = 130, Description = "Spacious bedroom with balcony access" },
                    new Space { Type = "Bathroom", Size = 70, Description = "Spa-style bathroom with soaking tub" }
                ]
            },
            new()
            {
                Address = "500 Tech Valley Dr, Austin, TX",
                Type = "Commercial",
                Price = 1450000,
                Description = "Modern office space in Austin’s tech corridor",
                Spaces =
                [
                    new Space { Type = "Conference Room", Size = 350, Description = "High-tech meeting space with AV setup" },
                    new Space { Type = "Open Workspace", Size = 1500, Description = "Flexible layout for teams and startups" },
                    new Space { Type = "Break Room", Size = 120, Description = "Fully stocked with coffee bar and snacks" }
                ]
            }
        };

        return properties;
    }
}
