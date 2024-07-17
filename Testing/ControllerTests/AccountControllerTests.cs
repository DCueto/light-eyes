﻿using light_eyes.Controllers;
using light_eyes.DTO.Account;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Testing.ControllerTests;

public class AccountControllerTests
{
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<ITokenService> _tokenserviceMock;
    private readonly Mock<SignInManager<AppUser>> _signinManagerMock;
    private readonly AccountController _accountController;

    public AccountControllerTests()
    {
        _userManagerMock = new Mock<UserManager<AppUser>>(
            new Mock<IUserStore<AppUser>>().Object, null, null, null, null, null, null, null, null);
        _tokenserviceMock = new Mock<ITokenService>();

        _signinManagerMock = new Mock<SignInManager<AppUser>>(
            _userManagerMock.Object,
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object,
            null,null,null,null);
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

    
}
