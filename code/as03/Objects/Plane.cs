namespace as03.Objects;

public class Plane
{
    public double D { get; }
    public Point3D[]? Points { get; }

    private Vector3D? _normal;
    public Vector3D Normal
    {
        get
        {
            if (_normal != null) return _normal;
            if (Points == null) return new Vector3D(0, 0, 0);

            var q = (Vector3D) Points[0];
            var r = (Vector3D) Points[1];
            var s = (Vector3D) Points[2];

            var qr = r - q;
            var qs = s - q;

            var normal = Vector3D.Cross(qr, qs);

            return normal;
        }
        
        set => _normal = value;
    }

    public Plane(Point3D[] points)
    {
        Points = points;
    }
    public Plane(Vector3D normal, double d)
    {
        Normal = normal;
        D = d;
    }

    public Plane(Point3D[] points, Vector3D normal)
    {
        Points = points;
        Normal = normal;
    }

    public override string ToString()
    {
        if (Points == null) return "Plane with normal: " + Normal;

        return "Plane with points: " + Points[0] + ", " +
               Points[1] + ", " + Points[2];
    }
}