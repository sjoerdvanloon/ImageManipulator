namespace ImageManipulator.Decorator;

sealed class Circle : Shape
{
    private float _radius;

    public Circle(float radius)
    {
        _radius = radius;
    }

    public override string AsString() => $"Circle with radius {_radius}";
}