using HyundaiTracker.Core.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HyundaiTracker.Infrastructure.Data;

public static class SeedData
{
    public static readonly Vehicle Kona = new("KM8HE3A67RU016674");
    public static readonly Vehicle Ioniq5 = new("KM8KRDDF4RU308813");
    public static readonly Vehicle Ioniq6 = new("KMHM54ACXRA079859");
    public static readonly Vehicle SantaFe = new("5NMP34G10RH005353");

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

        if (dbContext.Vehicles.Any())
        {
            return; // DB has been seeded
        }

        PopulateTestData(dbContext);
    }

    public static void PopulateTestData(AppDbContext dbContext)
    {
        foreach (var vehicle in dbContext.Vehicles)
        {
            dbContext.Remove(vehicle);
        }

        dbContext.SaveChanges();

        dbContext.Vehicles.Add(Kona);
        dbContext.Vehicles.Add(Ioniq5);
        dbContext.Vehicles.Add(Ioniq6);
        dbContext.Vehicles.Add(SantaFe);

        dbContext.SaveChanges();
    }
}
