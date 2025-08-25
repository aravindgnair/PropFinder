using Microsoft.EntityFrameworkCore;
using PropFinder.Infrastructure;
using PropFinder.Infrastructure.Persistence;
using PropFinder.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PropFinderDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:60606",
            "https://propfinder.azurestaticapps.net"
            ).AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<PropFinderDbContext>();

    db.Database.Migrate();         // Apply migrations
    SeedData.Initialize(db);       // Seed sample data
}

app.Run();
