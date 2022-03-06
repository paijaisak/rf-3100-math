using System;
using as03.Objects;
using NUnit.Framework;

namespace math_tests;

[TestFixture]
public class LineTests
{
    [Test]
    public void TestIntersections()
    {
        // F and g intersects, h does not intersect with either
        var f = new Line3D(new Vector3D(0, 0, 0), new Vector3D(2, 4, 6));
        var g = new Line3D(new Vector3D(2, 6, 10), new Vector3D(-1, -4, -7));

        var h = new Line3D(new Vector3D(-1, -3, -6),  new Vector3D(7, 5, 6));

        // If one point, intersection. If two, calculate closest distance 

        var res = f.Intersects(g, out var points);

        if (res)
        {
            Console.WriteLine("Lines:\n     " + f + ",\nand:\n      " +
                              g + "\nintersect at: " + points![0] + "\n");
        }

        Assert.IsTrue(res);

        res = f.Intersects(h, out points);

        Assert.False(res);

        if (!res)
        {
            Console.WriteLine("Distance between lines:\n        " + f + ",\nand:\n      " + h + "\nis: " +
                              Math.Round(Point3D.Distance(points![0], points[1]), 2) + "\n");
        }
    }

    [Test]
    public void TestParallelLines()
    {
        var r = new Line3D(new Vector3D(0, 0, 0), new Vector3D(2, 4, 6));
        var s = new Line3D(new Vector3D(2, 6, 10), new Vector3D(1, 2, 3));

        var q = new Line3D(new Vector3D(6, 12, 1),  new Vector3D(6, 2, 4));

        Assert.IsTrue(Line3D.AreParallel(r, s));
        Assert.IsFalse(Line3D.AreParallel(r, q));
    }
}