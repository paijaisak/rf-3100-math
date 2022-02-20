namespace as03.Objects;

public class Plane
{
    public Point3D[]? Points { get; }

    private double _d;
    public double D
    {
        get
        {
            if (_d != 0) return _d;
            if (Points == null) return 0;
                
            return Normal.x * Points[0].x + Normal.y * Points[0].y + Normal.z * Points[0].z;
        }

        set => _d = value;
    }

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

        return "Plane with definition: " + Normal.x + "x + " +
               Normal.y + "y + " + Normal.z + "z = " + D;
    }
}