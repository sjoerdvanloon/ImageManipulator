using System.Diagnostics;
using FluentAssertions;

namespace ImageManipulator.Decorator.Tests;

public class DecoratorTests
{
    [Test]
    public void Test1()
    {
        var circle = new Circle(2f);
        circle.AsString().Should().Be("Circle with radius 2");
        
        var coloredCircle = new ColoredShape(circle, "red");
        coloredCircle.AsString().Should().Be("Circle with radius 2 has the color red");
        
        var coloredCircle2 = new ColoredShape(coloredCircle, "blue");
        coloredCircle2.AsString().Should().Be("Circle with radius 2 has the color red");

      
       var  gFoo = new Foo<int>();
       if (gFoo is Foo f)
           f.GeenGenericFunction();
        gFoo.Get(1);
        gFoo.GeenGenericFunction();

    }

    public class Foo
    {
        public int GeenGenericFunction() { return 1;}
    }


    public class Foo<T> :Foo
    {
        public void Get(T x)
        {
            Debug.Assert(x != null, nameof(x) + " != null");
            System.Diagnostics.Trace.Write(x.ToString());
        }
    }
}

