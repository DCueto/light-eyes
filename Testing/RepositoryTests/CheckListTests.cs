using light_eyes.Data;
using light_eyes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Testing.RepositoryTests;

public class CheckListTests
{
    private readonly AppDbContext _context;
    private readonly Mock<ICheckListRepository> _checkListMock;

    public CheckListTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "")
            .Options;
        _checkListMock = new Mock<ICheckListRepository>();
    }
}