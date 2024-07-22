using light_eyes.Data;
using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Interfaces;
using light_eyes.Models;
using light_eyes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Testing.RepositoryTests;

public class CheckListItemTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly ICheckListItemRepository _repository;
    private readonly CheckListItem _testsCheckListItem;

    public CheckListItemTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new CheckListItemRepository(_context);

        _testsCheckListItem = new CheckListItem
        {
            CheckListItemId = 1,
            Name = "InitialCheckListItem",
            Content = "InitialContent",
            Language = "en"
        };

        SeedDatabase().Wait();
    }

    private async Task SeedDatabase()
    {
        _context.CheckListItem.Add(_testsCheckListItem);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCheckListItems()
    {
        var checkListItems = new List<CheckListItem>
        {
            new CheckListItem { CheckListItemId = 2, Name = "CheckListItem2", Content = "Content2", Language = "en1"},
            new CheckListItem { CheckListItemId = 3, Name = "CheckListItem3", Content = "Content3", Language = "en2" }
        };
        
        await _context.CheckListItem.AddRangeAsync(checkListItems);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();
        
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOneCheckListItem()
    {
        var result = await _repository.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("InitialCheckListItem", result.Name);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCreateCheckList()
    {
        var newCheckListItem = new CheckListItem
        {
            CheckListItemId = 2,
            Name = "NewCheckListItem",
            Content = "NewContent",
            Language = "pt"
        };

        var result = await _repository.CreateAsync(newCheckListItem);
        var allCheckListItems = await _repository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(2, allCheckListItems.Count);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCheckListItem()
    {
        var updateCheckListItemDto = new UpdateCheckListItemDto
        {
            Name = "UpdateName",
            Content = "UpdateContent"
        };

        var result = await _repository.UpdateAsync(1, updateCheckListItemDto);
        var updateCheckListItem = await _repository.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("UpdateName", updateCheckListItem?.Name);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteCheckListItem()
    {
        var result = await _repository.DeleteAsync(1);
        var allCheckListItems = await _repository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Empty(allCheckListItems);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrueOrFalseIfExistsOrNot()
    {
        // Act
        var exists = await _repository.ExistsAsync(1);
        var nonExists = await _repository.ExistsAsync(999);

        // Assert
        Assert.True(exists);
        Assert.False(nonExists);
    }
}