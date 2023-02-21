namespace ImageManipulator;

public interface IImageManipulator
{
    ImageManipulator RoundCorners();
    ImageManipulator Resize();
    ImageManipulator ResizeWhen(Func<ImageData, bool> predicate);
    ImageManipulator AddPrimitive();
    ImageManipulator AddText(string s);

    ImageData GetImageData();
}