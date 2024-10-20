using AutoBogus;
using FluentAssertions;
using Mapster;
using Moq;
using Moq.EntityFrameworkCore;

namespace MapsterSample.Tests;

[Collection(nameof(MapsterCollectionNonParallelized))]
public class ProjectionTests
{
    public ProjectionTests()
    {
        TypeAdapterConfig<User, UserDTO>.NewConfig().Map(dest => dest.Address, src => src.Address.Street);
    }

    [Fact]
    public void GetUsers_ShouldReturnProjectedUserDTO()
    {
        // Arrange
        var fakeUsers = new AutoFaker<User>().Generate(5);
        var mockContext = new Mock<IAppDbContext>();
        mockContext.Setup(c => c.Users).ReturnsDbSet(fakeUsers);
        var usersExpected = fakeUsers.Select(u => new UserDTO
        {
            Name = u.Name,
            Age = u.Age,
            Address = u.Address.Street
        });

        var userService = new UserService(mockContext.Object);

        // Act
        var users = userService.GetUsers().ToList();

        // Assert
        users.Should().BeEquivalentTo(usersExpected);
    }
}
