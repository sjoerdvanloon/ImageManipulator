namespace ImageManipulator.Decorator.Policies;

public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
{
    public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
    {
        return handler(type, allTypes);
    }

    public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
    {
        return handler(type, allTypes);
    }

    private static bool handler(Type type, IList<Type> allTypes)
    {
        if (allTypes.Contains(type))
            throw new InvalidOperationException("Cycle detected");
        return true;
    }
}