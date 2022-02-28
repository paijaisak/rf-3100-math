using System;
using as03.Objects;
using NUnit.Framework;
using NUnit.Framework.Internal;

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
        
        var res = f.Intersects(g, out var point);

        if (res)
        {
            Console.WriteLine("Lines intersect at: " + point);
        }

        Assert.IsTrue(res);

        res = f.Intersects(h, out point);

        Assert.False(res);

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