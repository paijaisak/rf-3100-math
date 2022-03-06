using as03.Objects;

namespace as03.Tests;

public class Point3DTests
{
    private static readonly Random random = new();

    private static readonly Point3D[] points = new Point3D[8];

    private static void InitializePoints()
    {
        for (var i = 0; i < 8; i++)
        {
            var x = (double)random.Next(0, 20);
            var y = (double)random.Next(0, 20);
            var z = (double)random.Next(0, 20);

            points[i] = new Point3D(x, y, z);
        }
    }

    private static void DistanceBetweenPoints()
    {
        var i = 0;
        while (i < 8)
        {
            Console.WriteLine(
                "Distance between points " + points[i] + " and " +
                              points[i + 1] + " is: " +
                              Math.Round(Point3D.Distance(points[i], points[i + 1]), 2) + "\n"
                );

            i += 2;
        }
    }

    public static void RunTests()
    {
        InitializePoints();
        DistanceBetweenPoints();
    }
}