using Mapster;
using FluentAssertions;
using AutoBogus;

namespace MapsterSample.Tests;

[Collection(nameof(MapsterCollectionNonParallelized))]
public class MappingTests
{
    public MappingTests()
    {
        TypeAdapterConfig<User, UserDTO>.Clear();
    }

    [Fact]
    public void MapUserWithAddressToDTOShouldFlattenCorrectly()
    {
        // Arrange
        var user = new AutoFaker<User>().Generate();

        // Act
        var userDto = user.Adapt<UserDTO>();

        // Assert
        userDto.Should().BeEquivalentTo(new
        {
            user.Name,
            user.Age
        });
    }

    [Fact]
    public void CustomMappingShouldApplyConfigurationCorrectly()
    {
        // Arrange
        TypeAdapterConfig<User, UserDTO>.NewConfig()
            .Map(dest => dest.Name, src => src.Name.ToUpper())
            .Map(dest => dest.Age, src => src.Age + 1)
            .Map(dest => dest.Address, src => src.Address.Street);

        var user = new AutoFaker<User>().Generate();

        // Act
        var userDto = user.Adapt<UserDTO>();

        // Assert
        userDto.Name.Should().Be(user.Name.ToUpper());
        userDto.Age.Should().Be(user.Age + 1);
        userDto.Address.Should().Be(user.Address.Street);
    }
}
