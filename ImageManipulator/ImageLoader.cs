namespace ImageManipulator;

public class ImageLoader
{
    public ImageLoader()
    {
      
    }

    public byte[] LoadBase64(string base64)
    {
        if (base64 == null) throw new ArgumentNullException(nameof(base64));
        return Convert.FromBase64String(base64) ;
    }

    public byte[] LoadByBytes(byte[] image)
    {
        if (image == null) throw new ArgumentNullException(nameof(image));
        return image.ToArray();
    }
}

