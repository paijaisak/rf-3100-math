using as03.Objects;
using NUnit.Framework;
using System;

namespace math_tests;

[TestFixture]
public class LinePlaneTest
{
    [Test]
    public void TestIntersection()
    {
        #region Case ONE

        var plane = new Plane(new Vector3D(2, -1, 3), 15);

        var line = new Line3D(new Vector3D(4, -1, 4), new Vector3D(1, 8, -2));

        var res = line.Intersects(plane, out var point, out var distance);

        Assert.IsTrue(res);
        Assert.IsTrue(distance == 0);

        if (res)
        {
            Console.WriteLine(line + "\n    and:\n" + plane + "\n   intersect in the point: " + point);
        }

        #endregion

        var points = new Point3D[]
        {
            new(0, 1, 4),
            new(5, 9, 2),
            new(5, 2, 6),
        };

        // GEOGEBRA

        /*
         * Plan((0, 1, 4), (5, 9, 2), (5, 2, 6))
         */

        /*
         * Linje((0, 0, 0), (2, 4, 6))
         */

        var p = new Plane(points);
        var l = new Line3D(new Vector3D(0, 0, 0), new Vector3D(2, 4, 6));

        res = l.Intersects(p, out point, out distance);

        Assert.IsTrue(res);
        Assert.IsTrue(distance == 0);

        if (res)
        {
            Console.WriteLine(l + "\n    and:\n" + p + "\n   intersect in the point: " + point);
        }
    }

    [Test]
    public void TestParallel()
    {
        // Line and plane are parallel
        var l = new Line3D(new Vector3D(2, 0, -1), new Vector3D(1, 1, 1));
        var p = new Plane(new Vector3D(1, 1, -2), -3);

        var res = l.Intersects(p, out var point, out var distance);

        Assert.IsFalse(res);
        Assert.IsNull(point);

        Console.WriteLine("Distance between\n   " + l + "\nand\n    " + p + "\nis: " + distance);
    }
}