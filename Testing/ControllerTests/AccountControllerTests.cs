using light_eyes.Controllers;
using light_eyes.DTO.Account;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using Moq;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace Testing.ControllerTests;

public class AccountControllerTests
{
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<ITokenService> _tokenserviceMock;
    private readonly Mock<SignInManager<AppUser>> _signinManagerMock;
    private readonly AccountController _accountController;

    public AccountControllerTests()
    {
        var userStoreMock = new Mock<IUserStore<AppUser>>();
        _userManagerMock = new Mock<UserManager<AppUser>>(
            userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);

        _tokenserviceMock = new Mock<ITokenService>();

        var contextAccessorMock = new Mock<IHttpContextAccessor>();
        var userPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<AppUser>>();

        _signinManagerMock = new Mock<SignInManager<AppUser>>(
            _userManagerMock.Object,
            contextAccessorMock.Object,
            userPrincipalFactoryMock.Object,
            null!, null!, null!, null!);

        _accountController = new AccountController(
            _userManagerMock.Object,
            _tokenserviceMock.Object,
            _signinManagerMock.Object);
    }

    [Fact]
    public async Task Login_invalidModelState_ReturnsBadRequest()
    {
        _accountController.ModelState.AddModelError("UserName", "Required");
    
        var result = await _accountController.Login(new LoginDto());
    
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }
    
    [Fact]
    public async Task Register_ValidData_ReturnsOkResult()
    {
        var registerDto = new RegisterDto
        {
            UserName = "testUser",
            Email = "test@test.com",
            Password = "P@ssw0rd"
        };
    
        _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        _userManagerMock.Setup(m => m.AddToRoleAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        _tokenserviceMock.Setup(m => m.CreateToken(It.IsAny<AppUser>()))
            .Returns("testToken");
    
        var result = await _accountController.Register(registerDto);
    
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var newUserDto = Assert.IsType<NewUserDto>(okObjectResult.Value);
        Assert.Equal(registerDto.UserName, newUserDto.UserName);
        Assert.Equal(registerDto.Email, newUserDto.Email);
        Assert.Equal("testToken", newUserDto.Token);
    }
    
    [Fact]
    public async Task Register_InvalidModel_ReturnsBadRequest()
    {
        var registerDto = new RegisterDto();
        _accountController.ModelState.AddModelError("UserName", "UserName is required");
    
        var result = await _accountController.Register(registerDto);
    
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }
    [Fact]
    public async Task Login_UserNotFound_ReturnsUnauthorized()
    {
        // Arrange
        var users = new List<AppUser>().AsQueryable().BuildMock();
        _userManagerMock.Setup(m => m.Users).Returns(users);
    
        var loginDto = new LoginDto { UserName = "nonexistentUser", Password = "anyPassword" };
        
        var result = await _accountController.Login(loginDto);
        
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Invalid Username!", unauthorizedResult.Value);
    }
    [Fact]
    public async Task Login_ValidCredentials_ReturnsOk()
    {
        
        var user = new AppUser { UserName = "testUser", Email = "test@test.com" };
        var loginDto = new LoginDto { UserName = "testUser", Password = "correctPassword" };
        
        _userManagerMock.Setup(m => m.FindByNameAsync(loginDto.UserName.ToLower()))
            .ReturnsAsync(user);

        _signinManagerMock.Setup(m => m.CheckPasswordSignInAsync(user, loginDto.Password, false))
            .ReturnsAsync(SignInResult.Success);
        
        _tokenserviceMock.Setup(m => m.CreateToken(user))
            .Returns("testToken");
        
        var result = await _accountController.Login(loginDto);
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var newUserDto = Assert.IsType<NewUserDto>(okResult.Value);
        Assert.Equal(user.UserName, newUserDto.UserName);
        Assert.Equal(user.Email, newUserDto.Email);
        Assert.Equal("testToken", newUserDto.Token);
    }
}

