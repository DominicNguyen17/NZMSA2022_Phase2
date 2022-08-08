using backend.Controllers;
using backend.Model;
using backend.Services;
using FluentAssertions;
using NUnit.Framework;

namespace WebApiTest.UserUnitTests
{
    public class GetUser
    {
        [Test]
        public async Task TakeId_GetUserName_CompareToExpectedName()
        {
            var _context = new NZMSA2022_PokemonContext();
            var _userServices = new UserServices(_context);
            UsersController usersController = new UsersController(_context, _userServices);

            User user = new User
            {
                UserId = 1,
                UserName = "Phu",
                BirthDate = 18,
                BirthMonth = 2,
                BirthYear = 2001
            };

            var user1 = await usersController.GetUser(1);
            user1.UserName.Should().Be(user.UserName);
        }
    }
}
