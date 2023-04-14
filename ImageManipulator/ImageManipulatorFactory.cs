namespace ImageManipulator;

public class ImageManipulatorFactory
{
    private readonly ImageLoader _imageLoader;

    public ImageManipulatorFactory(ImageLoader imageLoader)
    {
        _imageLoader = imageLoader ?? throw new ArgumentNullException(nameof(imageLoader));
    }

    public IImageManipulator CreateImageManipulator(byte[] image)
    {
        return new ImageManipulator(image);
    }

    public IImageManipulator CreateImageManipulatorWithBase64(string base64)
    {
        var image = _imageLoader.LoadBase64(base64);
        return CreateImageManipulator(image);
    }

    public IImageManipulator CreateImageManipulatorFromFileSystem(string path)
    {
        // var image = _imageLoader.LoadBase64(base64);
        //return CreateImageManipulator(image);
        return null;
    }
}