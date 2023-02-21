namespace ImageManipulator;

public class Manipulator
{
    private ManipulatorContext _currentContext;
    public Manipulator()
    {
      
    }
    
    public Manipulator LoadBase64(string base64)
    {
        _currentContext = new();
        return this;
    }

    public Manipulator RoundCorners()
    {
        return null;
    }

    public string SaveToBase64()
    {
        return "";
    }
    
    
}

public class ManipulatorContext
{
    public byte[] InitialData { get; set; }
    public byte[] CurrentData { get; set; }
}