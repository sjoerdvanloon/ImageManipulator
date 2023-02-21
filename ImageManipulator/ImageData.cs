using System.Drawing;

namespace ImageManipulator;

public class ImageData
{
    public ImageData(Size size, byte[] data)
    {
        Size = size;
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public Size Size { get; set; }
    public byte[] Data { get; set; }
}