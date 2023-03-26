using System;
using System.Threading.Tasks;
using Deytek.Controllers;
using Deytek.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace UnitTest
{
	public class UserControllerTest
	{
        [Fact]
        public async Task AddUser_ValidModelState_ReturnsRedirectToActionResult()
        {
            // Arrange
            var user = new UserSignUpViewModel
            {
                Mail = "test@example.com",
                UserName = "testuser",
                nameSurname = "Test User",
                Password = "A?c1=*902d_D"
            };
            var image = new Mock<IFormFile>();
            var userManager = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
            userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            var controller = new UserController(userManager.Object);

            // Act
            var result = await controller.AddUser(user, image.Object);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("UserList", redirectToActionResult.ActionName);
            Assert.Equal("User", redirectToActionResult.ControllerName);
        }
    }
}

