namespace Users.Tests;

// Using the Builder pattern - lots of method that mutate
// and return `this` 
public class UserBuilder
{
    private string _name;
    private int _age;
    private bool _registered;
    private bool _alreadyBuilt;

    public UserBuilder(string name, int age, bool registered)
    {
        _name = name;
        _age = age;
        _registered = registered;
    }

    public UserBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public UserBuilder Registered()
    {
        _registered = true;
        return this;
    }

    public User Build()
    {
        if (_alreadyBuilt)
        {
            throw new Exception("Builder object must not be re-used");
        }
        _alreadyBuilt = true;
        return new User(_name, _age, _registered);
    }
}

// To make test even nicer to write, we introduce a class with a static method called `Named`
// rather than having to write `var user = new UserBuilder().Name("Bob").Build()`
public class AUser
{
    public static UserBuilder Named(string name)
    {
        return new UserBuilder(name, 25, false);
    }
}

// This way, we can have different 'types' of users built with
// different classes
public class AMinor
{
    public static UserBuilder Named(string name)
    {
        return new UserBuilder(name, 16, false);
    }
}