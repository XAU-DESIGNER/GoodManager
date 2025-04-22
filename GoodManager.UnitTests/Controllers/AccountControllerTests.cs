using FluentAssertions;
using GoodManager.Application.Services.Interfaces.Users;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Account;
using GoodManager.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;

namespace GoodManager.UnitTests.Controllers;

public class AccountControllerTests
{
    #region Constructor

    private readonly Mock<IAccountService> _accountServiceMock;
    private readonly AccountController _accountController;

    public AccountControllerTests()
    {
        _accountServiceMock = new Mock<IAccountService>();
        _accountController = new AccountController(_accountServiceMock.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }

    #endregion

    #region Register tests

    [Fact]
    public void Register_Get_ReturnsViewWithNullModel()
    {
        //act
        var result = _accountController.Register(returnUrl: "");

        //assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult?.Model.Should().BeNull();
    }


    [Fact]
    public async Task Register_Post_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var model = new RegisterViewModel();
        _accountController.ModelState.AddModelError("Email", "Required");

        _accountController.TempData = new TempDataDictionary(new DefaultHttpContext(),
                                                             Mock.Of<ITempDataProvider>());

        // Act
        var result = await _accountController.Register(model);

        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult?.Model.Should().Be(model);
    }

    [Fact]
    public async Task Register_Post_ValidModel_ServiceFails_ReturnViewModel()
    {
        //arrange
        var model = new RegisterViewModel()
        {
            Email = "asd@gmail.com",
            Password = "12345678",
            RePassword = "12345678",
            ReturnUrl = "/",
            UserName = "123asd"
        };

        var serviceResult = Result.Failure(ErrorMessages.OperationFailedError);
        _accountServiceMock.Setup(x => x.RegisterAsync(model)).ReturnsAsync(serviceResult);

        //act
        var result = await _accountController.Register(model);

        //assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult?.Model.Should().Be(model);
    }

    #endregion

    #region Login tests



    #endregion
}