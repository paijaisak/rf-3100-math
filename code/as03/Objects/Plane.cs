namespace as03.Objects;

public class Plane
{
    //private Vector3D? normal;
    public double D { get; }
    public Vector3D[]? Points { get; }

    private Vector3D? _normal;
    public Vector3D? Normal
    {
        get
        {
            if (_normal != null) return _normal;
            if (Points == null) return new Vector3D(0, 0, 0);

            var n = Points.Length;

            double x = 0;
            double y = 0;
            double z = 0;

            for (var i = 0; i < n - 1; i++)
            {
                var p = Points[i];
                var pNext = Points[i + 1];

                x += (p.z + pNext.z) * (p.y - pNext.y);
                y += (p.x + pNext.x) * (p.z - pNext.z);
                z += (p.y + pNext.y) * (p.x - pNext.x);
            }

            // When the loop wraps to the start
            x += (Points[n - 1].z + Points[0].z) * (Points[n - 1].y - Points[0].y);
            y += (Points[n - 1].x + Points[0].x) * (Points[n - 1].z - Points[0].z);
            z += (Points[n - 1].y + Points[0].y) * (Points[n - 1].x - Points[0].x);

            x /= 2;
            y /= 2;
            z /= 2;

            var res = new Vector3D(x, y, z);

            return res;
        }
        set => _normal = value;
    }

    public Plane(Vector3D[] points)
    {
        Points = points;
    }
    public Plane(Vector3D normal, double d)
    {
        Normal = normal;
        D = d;
    }

    public Plane(Vector3D[] points, Vector3D normal)
    {
        Points = points;
        Normal = normal;
    }

    public override string ToString()
    {
        if (Points == null) return "Plane with normal: " + Normal;

        return "Plane with _points: " + Points[0] + ", " +
               Points[1] + ", " + Points[2];
    }
}