using System.Drawing;

namespace ImageManipulator;

public class Manipulator
{
    private ManipulatorContext _currentContext;
    private readonly ImageLoader _imageLoader;
    private readonly ImageSaver _imageSaver;

    public bool IsLoaded => _currentContext is not null;

    public Manipulator(ImageLoader imageLoader, ImageSaver imageSaver)
    {
        _imageLoader = imageLoader;
        _imageSaver = imageSaver;
    }

    #region Loader

    public Manipulator Load(string base64)
    {
        Load(() => _imageLoader.LoadBase64(base64));
        return this;
    }

    public Manipulator Load(byte[] image)
    {
        Load(() => _imageLoader.LoadByBytes(image));
        return this;
    }

    private void Load(Func<byte[]> loadFunc)
    {
        // if (IsLoaded)
        //     throw new Exception("Image already loaded");
        var image = loadFunc();
        _currentContext = new ManipulatorContext(image);
    }

    #endregion

    public Manipulator RoundCorners()
    {
        AssertLoaded();
        // Round corners
        return this;
    }

    public Manipulator Resize()
    {
        return this;
    }

    public Manipulator ResizeWhen(Func<ImageData, bool> predicate)
    {
        var imageData = GetImageData();
        if (predicate(imageData))
        {
            Resize();
        }
        
        return this;
    }

    #region Save

    public string SaveToBase64()
    {
        AssertLoaded();
        return _imageSaver.ToBase64(_currentContext.CurrentData);
    }

    public byte[] SaveToByteArray()
    {
        AssertLoaded();
        return _imageSaver.ToByteArray(_currentContext.CurrentData);
    }

    #endregion

    private ImageData GetImageData()
    {
        AssertLoaded();
        return new ImageData() {};
    }

    private void AssertLoaded()
    {
        if (!IsLoaded)
            throw new Exception("Image already loaded");
    }

    public Manipulator AddPrimitive()
    {
        throw new NotImplementedException();
    }

    public Manipulator AddText(string s)
    {
        throw new NotImplementedException();
    }
}

public class ImageData
{
    public Size Size { get; set; }
    public byte[] Data { get; set; }
}

public class ImageSaver
{
    public byte[] ToByteArray(byte[] image)
    {
        return image.ToArray();
    }

    public string ToBase64(byte[] image)
    {
        return null;
    }
}

public class ManipulatorContext
{
    public ManipulatorContext(byte[] image)
    {
        CurrentData = image;
    }

    // public byte[] InitialData { get; }
    public byte[] CurrentData { get; set; }
}