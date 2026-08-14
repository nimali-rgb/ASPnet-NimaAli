using CoreFitness.Application.Interfaces;
using CoreFitness.Application.Services;
using CoreFitness.Domain.Entities;
using CoreFitness.Infrastructure.Data;
using CoreFitness.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoreFitness.Tests
{
    public class BookingTests
    {
        private CoreFitnessDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CoreFitnessDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new CoreFitnessDbContext(options);
        }

        [Fact]
        public async Task User_Cannot_Book_Same_Class_Twice()
        {
            // Arrange
            var context = GetDbContext();
            var repository = new BookingRepository(context);
            var service = new BookingService(repository);

            var userId = "test-user";
            var gymClassId = 1;

            // Seed a gym class
            context.GymClasses.Add(new GymClass
            {
                Id = gymClassId,
                Name = "Yoga",
                Date = DateTime.Now,
                Time = TimeSpan.Parse("10:00")

            });

            await context.SaveChangesAsync();

            // Act
            var firstBooking = await service.BookAsync(userId, gymClassId);
            var secondBooking = await service.BookAsync(userId, gymClassId);

            // Assert
            Assert.True(firstBooking);   // first booking should succeed
            Assert.False(secondBooking); // second booking should fail
        }
    }
}
