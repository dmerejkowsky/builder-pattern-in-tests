namespace Users.Tests;


public class UsersTests
{

    [Test]
    public void TestUsingBuilders()
    {
        var alice = AUser.Named("Alice").Build();
        var bob = AUser.Named("Bob").Registered().Build();
        var charlie = AMinor.Named("Charlie").Build();

        Assert.Multiple(() =>
        {
            Assert.That(alice.Name, Is.EqualTo("Alice"));

            Assert.That(bob.Name, Is.EqualTo("Bob"));
            Assert.That(bob.Registered, Is.True);

            Assert.That(charlie.Name, Is.EqualTo("Charlie"));
            Assert.That(charlie.Age, Is.LessThan(18));
        });
    }

    [Test]
    public void DontUseTheBuilderDirectly()
    {
        var builder = new UserBuilder("One", 20, false);
        var alice = builder.Named("One").Registered().Build();
        var bob = builder.Named("Two").Build();
    }
}