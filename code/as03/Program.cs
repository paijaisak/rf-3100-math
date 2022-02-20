using as03.Objects;
using as03.Tests;

namespace as03;

internal class Program
{
    private static void Main()
    {
        //Console.WriteLine("Hello World!");
        Point3DTests.RunTests();
        Console.WriteLine("-------------------------------------------\n");
        PlaneTests.RunTests();
    }
}