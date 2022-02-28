using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace as03.Objects;

public class Line3D
{
    // Point
    public Vector3D P { get; }

    // Direction
    public Vector3D V { get; }

    public Line3D(Vector3D point, Vector3D direction)
    {
        P = point;
        V = direction;
    }

    public bool Intersects(Line3D line, out Point3D? point)
    {
        // Points
        var r1 = P;
        var r2 = line.P;

        // Direction vectors
        var v1 = Vector3D.Normalize(V);
        var v2 = Vector3D.Normalize(line.V);

        // Direction projection
        var u = v1 * v2;

        // If lines are parallel in both positive and negative directions
        if (Math.Abs(u - 1) < 0.000001 || Math.Abs(u - (-1)) < 0.000001)
        {
            point = null;
            return false;
        }

        // Separation projections
        var t1 = (r2 - r1) * v1;
        var t2 = (r2 - r1) * v2;

        // Distances along lines
        var d1 = (t1 - (u * t2)) / (1 - (u * u));
        var d2 = (t2 - (u * t1)) / ((u * u) - 1);

        // Find the points of intersection
        var p1 = r1 + (d1 * v1);
        var p2 = r2 + (d2 * v2);

        if (p1 != p2)
        {
            point = null;
            return false;
        }

        point = (Point3D) p1;

        return true;

        //    var t = ( ((p2 - p1).Cross(v2)) * (v1.Cross(v2)) ) 
        //        / ( ((v1.Cross(v2)).Length) * ((v1.Cross(v2)).Length) );

        //    var s = ( ((p1 - p2).Cross(v1)) * (v2.Cross(v1)) ) 
        //            / ( ((v2.Cross(v1)).Length) * ((v2.Cross(v1)).Length) );

        //    var res = Math.Abs(t - s) < 0.000001 &&
        //              !AreParallel(this, line);
        //    if (res)
        //    {
        //        point = (Point3D) (p1 + (t * v1));
        //    }

        //    else if (double.IsNaN(t) || double.IsNaN(s))
        //    {
        //        point = (Point3D) (p1 + (t * v1));
        //    }

        //    else
        //    {
        //        if (AreParallel(this, line))
        //        {
        //            Debug.WriteLine("\nLines are parallel\n");
        //        }

        //        point = null;
        //    }

        //    return res;
        //}
    }

    public static bool AreParallel(Line3D l, Line3D m)
    {
        return l.V.Cross(m.V) == new Vector3D(0, 0, 0);
    }
}