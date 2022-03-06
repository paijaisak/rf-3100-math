namespace as03.Objects;

public class Point3D
{
    public double x, y, z;

    public Point3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // CASTING OPERATOR
    public static explicit operator Vector3D(Point3D p)
    {
        return new Vector3D(p.x, p.y, p.z);
    }

    public static double Distance(Point3D a, Point3D b)
    {
        var d = (Vector3D) a - (Vector3D) b;
        return d.Length;
    }

    public double Distance(Plane plane)
    {
        var a = (plane.Normal * (Vector3D) this + plane.D) / plane.Normal.Length;

        if (a < 0)
        {
            a *= -1;
        }

        return a;
    }

    public bool IsOnPlane(Plane plane)
    {
        var res = (plane.Normal.x * x) + (plane.Normal.y * y) + (plane.Normal.z * z) - plane.D;

        return Math.Abs(res) < 0.001 && Math.Abs(res) >= 0;
    }

    public override string ToString()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }
}