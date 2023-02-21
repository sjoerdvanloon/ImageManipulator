using Microsoft.Extensions.DependencyInjection;

namespace ImageManipulator;

public class Tests
{
    private ImageSaver _imageSaver;
    private ImageLoader _imageLoader;
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
    }

    [Test]
    public void Load_WithBase64_ShouldLoad()
    {
        var imageManipulator = _imageManipulatorFactory.CreateImageManipulator(TestData.InputImage);
        
            imageManipulator
                .ResizeWhen((image) => image.Size.Height != 600)
                .RoundCorners();
        
            _imageManipulatorFactory.SaveImageManipulator(imageManipulator);


            // _imageManipulator
            //     .Load("")
            //     .ResizeWhen((image) => image.Size.Height != 600)
            //     .AddPrimitive()
            //     .AddText("10:30")
            //     .SaveToBase64();
    }
}