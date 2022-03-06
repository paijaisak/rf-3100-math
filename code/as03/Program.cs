using as03.Tests;

namespace as03;

internal class Program
{
    private static void Main()
    {
        Point3DTests.RunTests();
        Console.WriteLine("-------------------------------------------\n");
        PlaneTests.RunTests();
    }
}