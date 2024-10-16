﻿using light_eyes.Data;
using light_eyes.DTOs.CheckList;
using light_eyes.Interfaces;
using light_eyes.Models;
using light_eyes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Testing.RepositoryTests;

public class CheckListTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly ICheckListRepository _checkListRepository;

    public CheckListTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "webApi")
            .Options;

        _context = new AppDbContext(options);
        _checkListRepository = new CheckListRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        _context.Dispose();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCheckLists()
    {
        var checkLists = new List<CheckList>
        {
            new CheckList
            {
                CheckListId = 1,
                Name = "CheckList1", Description = "Description1", Language = "en"
            },
            new CheckList
            {
                CheckListId = 2, Name = "CheckList2", Description = "Description2", Language = "en"
            }
        };

        await _context.CheckList.AddRangeAsync(checkLists);
        await _context.SaveChangesAsync();
        
        var result = await _checkListRepository.GetAllAsync();
        
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectCheckList()
    {
        
        var checkList = new CheckList
            { CheckListId = 1, Name = "CheckList1", Description = "Description1", Language = "en" };
        await _context.CheckList.AddAsync(checkList);
        await _context.SaveChangesAsync();
        
        var result = await _checkListRepository.GetByIdAsync(1);
        
        Assert.NotNull(result);
        Assert.Equal("CheckList1", result.Name);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddCheckList()
    {
        var checkList = new CheckList
            { CheckListId = 1, Name = "CheckList1", Description = "Description1", Language = "en" };

        var result = await _checkListRepository.CreateAsync(checkList);
        var allCheckLists = await _checkListRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Single(allCheckLists);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldDeleteCheckLIst()
    {
        var checkList = new CheckList { CheckListId = 1, Name = "CheckList1", Description = "Description1", Language = "en" };
        await _context.CheckList.AddAsync(checkList);
        await _context.SaveChangesAsync();

        var result = await _checkListRepository.DeleteAsync(1);
        var allCheckLists = await _checkListRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Empty(allCheckLists);
    }

    [Fact]
    public async Task ExistAsync_ShouldReturnTrueOrFalseIfExists()
    {
        var checkList = new CheckList { CheckListId = 1, Name = "CheckList1", Description = "Description1", Language = "en" };
        await _context.CheckList.AddAsync(checkList);
        await _context.SaveChangesAsync();
    
        var exists = await _checkListRepository.ExistsAsync(1);
        Assert.True(exists);
        
        var nonExistent = await _checkListRepository.ExistsAsync(2);
        Assert.False(nonExistent);
    }
}