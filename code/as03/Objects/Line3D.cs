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

    public bool Intersects(Line3D line, out Point3D? p)
    {
        var p1 = P;
        var p2 = line.P;

        var v1 = V;
        var v2 = line.V;

        var t = ( ((p2 - p1).Cross(v2)) * (v1.Cross(v2)) ) 
            / ( ((v1.Cross(v2)).Length) * ((v1.Cross(v2)).Length) );

        var s = ( ((p1 - p2).Cross(v1)) * (v2.Cross(v1)) ) 
                / ( ((v2.Cross(v1)).Length) * ((v2.Cross(v1)).Length) );

        var res = Math.Abs(t - s) < 0.000001 &&
                  !AreParallel(this, line);
        if (res)
        {
            p = (Point3D) (p1 + (t * v1));
        }

        else if (double.IsNaN(t) || double.IsNaN(s))
        {
            p = (Point3D) (p1 + (t * v1));
        }

        else
        {
            if (AreParallel(this, line))
            {
                Debug.WriteLine("\nLines are parallel\n");
            }

            p = null;
        }

        return res;
    }

    public static bool AreParallel(Line3D l, Line3D m)
    {
        return l.V.Cross(m.V) == new Vector3D(0, 0, 0);
    }
}