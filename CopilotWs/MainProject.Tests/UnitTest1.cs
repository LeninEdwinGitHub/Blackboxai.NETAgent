using MainProject;

namespace MainProject.Tests;

public class Class1Tests
{
    [Fact]
    public void Class1_CanBeInstantiated()
    {
        var instance = new Class1();
        Assert.NotNull(instance);
    }

    [Fact]
    public void Class1_TypeIsCorrect()
    {
        var instance = new Class1();
        Assert.IsType<Class1>(instance);
    }

    [Fact]
    public void Class1_Equality_DefaultInstancesAreNotSameReference()
    {
        var a = new Class1();
        var b = new Class1();
        Assert.NotSame(a, b);
    }
}
