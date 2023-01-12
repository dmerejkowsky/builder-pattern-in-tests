using Shouldly;
namespace Users.Tests;


public class UsersTests
{

    [Test]
    public void TestUsingBuilders()
    {
        var alice = AUser.Named("Alice").Build();
        alice.Name.ShouldBe("Alice");

        var bob = AUser.Named("Bob").Registered().Build();
        bob.Name.ShouldBe("Bob");
        bob.ShouldBeRegistered();

        var charlie = AMinor.Named("Charlie").Build();
        charlie.Name.ShouldBe("Charlie");
        charlie.Age.ShouldBeLessThan(18);
    }

    [Test]
    public void DontUseTheBuilderDirectly()
    {
        var builder = new UserBuilder("One", 20, false);
        var alice = builder.Named("One").Registered().Build();
        Should.Throw<Exception>(() => builder.Named("Two").Build());
    }
}