using System;
using SWAPI.Domain.Entities;
using Xunit;

namespace SWAPI.UnitTests.EntitiesTests
{
    public class StarshipTests
    {
        [Fact]
        public void CalculateAutonomy_Should_Return_Unknown()
        {            
            // Arrange            
            Starship starship = new Starship();

            // Act
            var autonomy = starship.CalculateAutonomy(1000000, -1);

            // Assert
            Assert.Equal("unknown", autonomy);
        }

        [Fact]
        public void CalculateAutonomy_Should_Return_9_MGLT()
        {
            // Arrange            
            Starship starship = new Starship();
            starship.Consumables = "2 months";
            starship.MGLT = "75";

            // Act
            var consumable = starship.TransformConsumableToHours();
            var autonomy = starship.CalculateAutonomy(1000000, consumable);

            // Assert
            Assert.Equal("9", autonomy);
        }

        [Fact]
        public void TransformConsumableToHours_Should_Return_1440_Hours()
        {
            // Arrange            
            Starship starship = new Starship();
            starship.Consumables = "2 months";

            // Act
            var consumable = starship.TransformConsumableToHours();

            // Assert
            Assert.Equal(1440, consumable);
        }

        [Fact]
        public void TransformConsumableToHours_Should_Return_1Negative_Hours()
        {
            // Arrange            
            Starship starship = new Starship();
            starship.Consumables = "unknown";

            // Act
            var consumable = starship.TransformConsumableToHours();

            // Assert
            Assert.Equal(-1, consumable);
        }
    }
}
