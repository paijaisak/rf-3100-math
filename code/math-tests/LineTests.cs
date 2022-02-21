using System;
using System.Diagnostics;
using as03.Objects;
using NUnit.Framework;

namespace math_tests;

[TestFixture]
public class LineTests
{
    [Test]
    public void TestIntersections()
    {
        // FIRST TWO SHOULD NOT INTERSECT, THEY ARE PARALLEL
        var f = new Line3D(new Vector3D(0, 0, 0), new Vector3D(2, 4, 6));
        var g = new Line3D(new Vector3D(2, 6, 10), new Vector3D(1, 2, 3));

        var h = new Line3D(new Vector3D(-1, -2, -3),  new Vector3D(6, 2, 4));

        var res = f.Intersects(g, out var point);

        if (!res)
        {
            Console.WriteLine(point);
        }

        Assert.IsFalse(res);

        res = f.Intersects(h, out point);

        Assert.IsTrue(res);

        if (res)
        {
            Console.WriteLine("Lines intersect at: " + point);
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