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

    public static double Distance(Point3D a, Point3D b)
    {
        var v = Vector3D.VectorBetweenPoints(a, b);

        return v.Length;
    }

    public override string ToString()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }
}