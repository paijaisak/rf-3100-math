namespace as03.Objects;

public class Line3D
{
    // Point
    public Vector3D P { get; }

    // Direction vector
    public Vector3D V { get; }

    public Line3D( Vector3D point, Vector3D direction )
    {
        P = point;
        V = direction;
    }

    // Out => one point if there is an intersection
    // Out => two (closest) points if lines don't intersect and are not parallel
    public bool Intersects( Line3D line, out Point3D[]? points )
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
            points = null;
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

        // Out -> points
        points = new Point3D[2];
        points[0] = (Point3D)p1;
        points[1] = (Point3D)p2;

        return p1 == p2;
    }

    public bool Intersects( Plane plane, out Point3D? point, out double distance )
    {
        var normal = plane.Normal;

        // Scalar product is null if plane and line are parallel
        var product = normal * V;

        // Are they parallel?
        if (Math.Abs(product) < 0.000001)
        {
            point = null;
            distance = Distance(plane);
            return false;
        }

        // M and N used to calculate t
        var m = V.x * normal.x + V.y * normal.y + V.z * normal.z;
        var n = normal.x * P.x + normal.y * P.y + normal.z * P.z - plane.D;

        var t = -n / m;

        // X-, Y- and Z-values for the point of intersection
        var xIntersection = P.x + V.x * t;
        var yIntersection = P.y + V.y * t;
        var zIntersection = P.z + V.z * t;

        // Assign out parameters
        point = new Point3D(xIntersection, yIntersection, zIntersection);
        distance = 0;

        return true;
    }

    public double Distance( Plane plane )
    {
        var normal = plane.Normal;

        var u = normal.x * P.x + normal.y * P.y + normal.z * P.z - plane.D;

        //double distance = v.Length / n.Length;

        return u / normal.Length;
    }

    public static bool AreParallel( Line3D l, Line3D m )
    {
        return l.V.Cross(m.V) == new Vector3D(0, 0, 0);
    }

    public override string ToString()
    {
        return "Line defined by point: " + P + " and direction: " + V;
    }
}