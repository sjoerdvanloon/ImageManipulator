namespace ImageManipulator;

public class Point
{
    public int X { get; init; }
    public int Y { get; init; }

    private Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }

    /// <summary>
    /// Factory method
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static async Task<Point> CreateCartesianPointAsync(int x, int y)
    {
        var point = new Point(x, y);
        await point.InitAsync();
        return point;
    }

    private async Task<Point> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }


    public static Point CreatePolarPoint(int row, int theta)
    {
        return null;
    }
}