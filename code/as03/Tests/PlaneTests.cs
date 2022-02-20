using as03.Objects;

namespace as03.Tests;

public class PlaneTests
{
    private static readonly Plane[] planes = new Plane[3];

    private static readonly Point3D[] allPoints = new Point3D[9];

    private static readonly Point3D[] pointsA = new Point3D[3];
    private static readonly Point3D[] pointsB = new Point3D[3];
    private static readonly Point3D[] pointsC = new Point3D[3];

    private static readonly Random random = new();

    private static void InitializePoints()
    {
        for (var i = 0; i < 9; i++)
        {
            var x = (double) random.Next(0, 10);
            var y = (double) random.Next(0, 10);
            var z = (double) random.Next(0, 10);

            allPoints[i] = new Point3D(x, y, z);

            if (i < 3)
            {
                pointsA[i] = allPoints[i];
            }
        }

        pointsA[0] = allPoints[0];
        pointsA[1] = allPoints[1];
        pointsA[2] = allPoints[2];

        pointsB[0] = allPoints[3];
        pointsB[1] = allPoints[4];
        pointsB[2] = allPoints[5];

        pointsC[0] = allPoints[6];
        pointsC[1] = allPoints[7];
        pointsC[2] = allPoints[8];
    }

    private static void InitializePlanes()
    {
        planes[0] = new Plane(pointsA);
        planes[1] = new Plane(pointsB);
        planes[2] = new Plane(pointsC);
    }

    public static void RunTests()
    {
       InitializePoints();
       InitializePlanes();

        foreach (var p in planes)
        {
            Console.WriteLine(p + "\n");
        }

        Console.WriteLine("-------------------------------------------\n");
        
        var point = pointsA[0]; 
        var plane = planes[0]; 
        var distance = Math.Round(point.Distance(plane), 2);
        
        Console.WriteLine(
            "Distance between point " + point + " and " +
                          plane + " is: " + distance + "\n"
           );
    }
}