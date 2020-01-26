using DemoWebApplication.Controllers;
using Xunit;

namespace DemoWebApplication.Tests
{
    public class HomeController_GetMembershipTypeAsync
    {
        [Fact]
        public void Should_ReturnThree_When_PassesOneAndTwo()
        {
            // Arrange
            //
            var sUT = new HomeController();

            // Act
            //
            var result = sUT.Add(1, 2);

            // Assert
            //
            Assert.Equal(3, result);
        }
    }
}
