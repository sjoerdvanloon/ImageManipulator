using Microsoft.Extensions.DependencyInjection;

namespace ImageManipulator;

public class Tests
{
    private ImageSaver _imageSaver;
    private ImageManipulatorFactory _imageManipulatorFactory;

    [SetUp]
    public void Setup()
    {
        var serviceCollection = new ServiceCollection()
                .AddSingleton<ImageSaver>()
                .AddSingleton<ImageLoader>()
                .AddSingleton<ImageManipulatorFactory>()
            ;

        var container = serviceCollection.BuildServiceProvider();

        _imageManipulatorFactory = container.GetRequiredService<ImageManipulatorFactory>();
        _imageSaver = container.GetRequiredService<ImageSaver>();
    }
    private byte[] SaveImageManipulator(IImageManipulator imageManipulator)
    {
        if (imageManipulator == null) throw new ArgumentNullException(nameof(imageManipulator));
        var data = imageManipulator.GetImageData();
        return _imageSaver.ToByteArray(data.Data);
    }
    
    [Test]
    public void Load_WithBase64_ShouldLoad()
    {
        var imageManipulator = _imageManipulatorFactory.CreateImageManipulator(TestData.InputImage);
        
            imageManipulator
                .ResizeWhen((image) => image.Size.Height != 600)
                .RoundCorners();
        
            SaveImageManipulator(imageManipulator);


            // _imageManipulator
            //     .Load("")
            //     .ResizeWhen((image) => image.Size.Height != 600)
            //     .AddPrimitive()
            //     .AddText("10:30")
            //     .SaveToBase64();
    }
}