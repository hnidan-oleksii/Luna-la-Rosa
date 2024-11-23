using DAL.Context;
using DAL.Entities;
using DAL.Helpers.Params;
using DAL.Helpers.Search;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests;

[TestFixture]
public class FlowerRepositoryTests
{
    private static readonly byte[] Image =
    [
        151, 228, 163, 149, 207, 255, 70, 105, 156, 115, 196, 161, 205, 16, 52, 19, 91, 78, 163, 111, 132, 165,
        74, 223, 122, 14, 160, 156, 227, 193, 23, 108, 228, 142, 130, 78, 2, 33, 190, 15, 59, 83, 88, 240, 163,
        40, 24, 75, 233, 145, 235, 129, 227, 18, 188, 241, 154, 196, 26, 193, 94, 169, 134, 218, 91, 87, 189,
        63, 142, 230, 16, 57, 143, 147, 52, 48, 77, 90, 60, 82, 246, 85, 179, 81, 214, 149, 137, 209, 210, 144,
        180, 62, 7, 253, 177, 146, 205, 125, 148, 75
    ];

    private LunaContext _dbContext = default!;

    [OneTimeSetUp]
    public void GetContext()
    {
        var options = new DbContextOptionsBuilder<LunaContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var dbContext = new LunaContext(options);
        dbContext.Database.EnsureCreated();
        _dbContext = dbContext;
    }

    [SetUp]
    public async Task SeedDatabase()
    {
        _dbContext.Flowers.RemoveRange(_dbContext.Flowers);
        await _dbContext.Flowers.AddRangeAsync(
            new Flower
            {
                Id = 1,
                Name = "Rose",
                TypeId = 1,
                Color = "Red",
                Price = 10,
                AvailableQuantity = 100,
                Image = Image
            },
            new Flower
            {
                Id = 2,
                Name = "Tulip",
                TypeId = 2,
                Color = "Yellow",
                Price = 5,
                AvailableQuantity = 50,
                Image = Image
            }
        );
        await _dbContext.SaveChangesAsync();
    }

    [Test]
    public void GetByIdAsync_ThrowsKeyNotFoundException_WhenFlowerNotFound()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act & Assert
        Assert.ThrowsAsync<KeyNotFoundException>(async () => await flowerRepository.GetByIdAsync(0));
    }

    [Test]
    public async Task GetByIdAsync_ReturnsFlower_WhenFound()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        var result = await flowerRepository.GetByIdAsync(1);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Rose"));
        });
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllFlowers()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        var result = await flowerRepository.GetAllAsync();

        // Assert
        var enumerable = result.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(enumerable, Is.Not.Null);
            Assert.That(enumerable, Is.Not.Empty);
            Assert.That(enumerable, Has.Count.EqualTo(2));
        });
    }

    [TestCase(null, new[] { "Name" }, 2)]
    [TestCase("Rose", new[] { "Name" }, 1)]
    public async Task GetAllFlowersAsync_ReturnsFilteredFlowers_WhenSearchQueryProvided(string? searchQuery,
        string[] searchFields, int expectedCount)
    {
        // Arrange
        var flowerParams = new FlowerParams { SearchQuery = searchQuery };
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        var result = await flowerRepository.GetAllFlowersAsync(flowerParams, searchFields);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Has.Count.EqualTo(expectedCount));
        });
        if (searchQuery != null) Assert.That(result[0].Name, Contains.Substring(searchQuery));
    }

    [Test]
    public async Task GetFlowersGroupedByTypeAsync_ReturnsGroupedFlowers()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        var result = await flowerRepository.GetFlowersGroupedByTypeAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Keys, Has.Count.GreaterThanOrEqualTo(2));
        });
    }

    [Test]
    public async Task AddAsync_AddsFlowerToDatabase()
    {
        // Arrange
        var newFlower = new Flower
        {
            Name = "Daisy",
            TypeId = 3,
            Color = "White",
            Price = 3.5m,
            AvailableQuantity = 20,
            Image = Image
        };
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        await flowerRepository.AddAsync(newFlower);
        await _dbContext.SaveChangesAsync();

        // Assert
        var addedFlower = await _dbContext.Flowers.FirstOrDefaultAsync(f => f.Name == "Daisy");
        Assert.Multiple(() =>
        {
            Assert.That(addedFlower, Is.Not.Null);
            Assert.That(addedFlower!.Price, Is.EqualTo(3.5m));
        });
    }

    [Test]
    public void AddAsync_ThrowsArgumentNullException_WhenEntityIsNull()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await flowerRepository.AddAsync(null!));
    }

    [Test]
    public async Task UpdateAsync_UpdatesFlowerDetails()
    {
        // Arrange
        var flowerToUpdate = await _dbContext.Flowers.FirstAsync();
        flowerToUpdate.Price = 15.0m;
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        await flowerRepository.UpdateAsync(flowerToUpdate);
        await _dbContext.SaveChangesAsync();

        // Assert
        var updatedFlower = await _dbContext.Flowers.FindAsync(flowerToUpdate.Id);
        Assert.That(updatedFlower!.Price, Is.EqualTo(15.0m));
    }

    [Test]
    public void UpdateAsync_ThrowsArgumentNullException_WhenEntityIsNull()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await flowerRepository.UpdateAsync(null!));
    }

    [Test]
    public async Task DeleteAsync_RemovesFlowerFromDatabase()
    {
        // Arrange
        var flowerId = 1;
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act
        await flowerRepository.DeleteAsync(flowerId);
        await _dbContext.SaveChangesAsync();

        // Assert
        var deletedFlower = await _dbContext.Flowers.FindAsync(flowerId);
        Assert.That(deletedFlower, Is.Null);
    }

    [Test]
    public void DeleteAsync_ThrowsKeyNotFoundException_WhenFlowerNotFound()
    {
        // Arrange
        var searchHelper = new SearchHelper<Flower>();
        var flowerRepository = new FlowerRepository(_dbContext, searchHelper);

        // Act & Assert
        Assert.ThrowsAsync<KeyNotFoundException>(async () => await flowerRepository.DeleteAsync(999));
    }
}