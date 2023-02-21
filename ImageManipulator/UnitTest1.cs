namespace ImageManipulator;

public class Tests
{
    private Manipulator _manipulator;
    private ImageSaver _imageSaver;
    private ImageLoader _imageLoader;

    [SetUp]
    public void Setup()
    {
        _imageLoader = new();
        _imageSaver = new();
        _manipulator = new(_imageLoader, _imageSaver);
    }

    [Test]
    public void Load_WithBase64_ShouldLoad()
    {
        _manipulator
            .Load("")
            .ResizeWhen((image) => image.Size.Height != 600)
            .RoundCorners()
            .SaveToBase64();

        _manipulator
            .Load("")
            .ResizeWhen((image) => image.Size.Height != 600)
            .AddPrimitive()
            .AddText("10:30")
            .SaveToBase64();
    }
}