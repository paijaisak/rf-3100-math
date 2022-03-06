namespace as03.Objects;

public class Plane
{
    public Point3D[] Points { get; }

    private double _d;
    public double D
    {
        get => _d != 0 ? _d :
            CalculateD(Normal, Points);

        set => _d = value;
    }

    private Vector3D? _normal;
    public Vector3D Normal
    {
        get => _normal != null! ? _normal :
            CalculateNormal(Points);

        set => _normal = value;
    }

    private static double CalculateD( Vector3D normal, IReadOnlyList<Point3D> points )
    {
        return normal.x * points[0].x + normal.y * points[0].y + normal.z * points[0].z;
    }

    private static Vector3D CalculateNormal( IReadOnlyList<Point3D> points )
    {
        var q = (Vector3D)points[0];
        var r = (Vector3D)points[1];
        var s = (Vector3D)points[2];

        var qr = r - q;
        var qs = s - q;

        var normal = Vector3D.Cross(qr, qs);

        {
            while (normal.x % 2 == 0 && normal.y % 2 == 0 && normal.z % 2 == 0)
            {
                normal /= 2;
            }

            while (normal.x % 3 == 0 && normal.y % 3 == 0 && normal.z % 3 == 0)
            {
                normal /= 3;
            }
        }

        return normal;
    }

    public Plane( Point3D[] points )
    {
        Points = points;
        Normal = CalculateNormal(points);
        D = CalculateD(Normal, Points);
    }

    public Plane( Vector3D normal, double d )
    {
        Normal = normal;
        D = d;

        Points = new Point3D[3];

        Points[0] = GeneratePoint(1);
        Points[1] = GeneratePoint(2);
        Points[2] = GeneratePoint(3);
    }

    private Point3D GeneratePoint( double x )
    {
        var z = (-Normal.x * x - (Normal.y * x * 2) + D) / Normal.z;

        return new Point3D(x, 2 * x, z);
    }

    public override string ToString()
    {
        return "Plane with definition: " + Normal.x + "x + " +
               Normal.y + "y + " + Normal.z + "z = " + D;
    }
}