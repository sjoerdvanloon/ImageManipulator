using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace ImageManipulator;

public class PointTests
{

    [SetUp]
    public void Setup()
    {
        
         
    }
    
    [Test]
    public async Task CreateCartesianPointAsync_ShouldCreateCorrectPoint()
    {
       var point = await Point.CreateCartesianPointAsync(1,2);
       point.Should().NotBeNull();
       point.X.Should().Be(1);
       point.Y.Should().Be(2);
    }
}