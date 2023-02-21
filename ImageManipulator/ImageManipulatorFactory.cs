
namespace ImageManipulator;

public class ImageManipulatorFactory
{
    private readonly ImageLoader _imageLoader;
    private readonly ImageSaver _imageSaver;

    public ImageManipulatorFactory(ImageLoader imageLoader, ImageSaver imageSaver)
    {
        _imageLoader = imageLoader ?? throw new ArgumentNullException(nameof(imageLoader));
        _imageSaver = imageSaver  ?? throw new ArgumentNullException(nameof(imageSaver));
    }
    
    public IImageManipulator CreateImageManipulator(byte[] image)
    {
        return new ImageManipulator(image);
    }
    
    public IImageManipulator CreateImageManipulator(string base64)
    {
        var image = _imageLoader.LoadBase64(base64);
        return CreateImageManipulator(image);
    }

    public byte[] SaveImageManipulator(IImageManipulator imageManipulator)
    {
        if (imageManipulator == null) throw new ArgumentNullException(nameof(imageManipulator));
        var data = imageManipulator.GetImageData();
        return _imageSaver.ToByteArray(data.Data);
    }
}