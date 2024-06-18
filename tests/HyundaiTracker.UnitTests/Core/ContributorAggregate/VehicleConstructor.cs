using HyundaiTracker.Core.VehicleAggregate;
using Xunit;

namespace HyundaiTracker.UnitTests.Core.ContributorAggregate;

public class VehicleConstructor
{
    [Fact]
    public void VinIsValidatedOnCreation()
    {
        // Arrange
        const string validVin = "KM8JBCD17RU209918";
        const string invalidVin = "12345678901234567";
        
        // Act
        var vehicle = new Vehicle(validVin);
        
        // Assert
        Assert.Equal(validVin, vehicle.Vin);

        Assert.Throws<ArgumentNullException>(() => new Vehicle(null!));
        Assert.Throws<ArgumentException>(() => new Vehicle(invalidVin));
        Assert.Throws<ArgumentException>(() => new Vehicle("tooshortstring"));
    }
}
