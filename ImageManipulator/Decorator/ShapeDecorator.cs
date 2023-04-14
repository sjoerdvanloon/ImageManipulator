namespace ImageManipulator.Decorator;

public abstract class ShapeDecorator : Shape
{
    protected internal Shape _shape;
    protected internal readonly List<Type> _types = new();

    protected ShapeDecorator(Shape shape)
    {
        _shape = shape;
        if (shape is ShapeDecorator sd)
            _types.AddRange(sd._types);
    }
}

public abstract class ShapeDecorator<TSelf, TCyclePolicy>: ShapeDecorator where TCyclePolicy : ShapeDecoratorCyclePolicy, new()
{
    protected readonly TCyclePolicy _cyclePolicy = new();
    protected ShapeDecorator(Shape shape) : base(shape)
    {
   
        if (_cyclePolicy.TypeAdditionAllowed(typeof(TSelf), _types) )
            _types.Add(typeof(TSelf));
    }
}