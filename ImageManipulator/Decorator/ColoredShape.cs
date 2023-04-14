using System.Text;
using ImageManipulator.Decorator.Policies;

namespace ImageManipulator.Decorator;

public class ColoredShape : ShapeDecorator<ColoredShape, AbsorbCyclePolicy>
{
    private string _color;

    public ColoredShape(Shape shape, string color) : base(shape)
    {
        _color = color;
    }

    public override string AsString()
    {
        var sb = new StringBuilder($"{_shape.AsString()}");
        if (_cyclePolicy.ApplicationAllowed(_types[0], _types.Skip(1).ToList()))
            sb.Append($" has the color {_color}");
        return sb.ToString();
    }
}