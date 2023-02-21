using System.Drawing;

namespace ImageManipulator;

public class ImageManipulator : IImageManipulator
{
    private ImageManipulatorContext _currentContext;

    public ImageManipulator(byte[] image)
    {
        if (image == null) throw new ArgumentNullException(nameof(image));
        _currentContext = new ImageManipulatorContext(image);
    }

    public ImageManipulator RoundCorners()
    {
        // Round corners
        return this;
    }

    public ImageManipulator Resize()
    {
        return this;
    }

    public ImageManipulator ResizeWhen(Func<ImageData, bool> predicate)
    {
        var imageData = GetImageData();
        if (predicate(imageData))
        {
            Resize();
        }
        
        return this;
    }

    public ImageData GetImageData()
    {
        return new ImageData(new Size(), _currentContext.CurrentData.ToArray());
    }

    public ImageManipulator AddPrimitive()
    {
        throw new NotImplementedException();
    }

    public ImageManipulator AddText(string s)
    {
        throw new NotImplementedException();
    }

    public byte[] GetData()
    {
        throw new NotImplementedException();
    }
}