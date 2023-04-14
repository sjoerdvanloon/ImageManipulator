namespace ImageManipulator.Decorator;

sealed class Rectangle : Shape
{
    private int _width, _height;

    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public override string AsString() => "Rectangle";
}