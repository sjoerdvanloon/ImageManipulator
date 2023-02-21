namespace ImageManipulator;

public class ImageManipulatorContext
{
    public ImageManipulatorContext(byte[] image)
    {
        CurrentData = image.ToArray();
    }

    // public byte[] InitialData { get; }
    public byte[] CurrentData { get; set; }
}