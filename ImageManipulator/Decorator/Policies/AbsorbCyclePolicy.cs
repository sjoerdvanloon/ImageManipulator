namespace ImageManipulator.Decorator.Policies;

public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
{
    public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
    {
        return true;
    }

    public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
    {
        return !allTypes.Contains(type); // Do not apply decorator if it is already applied
    }
}