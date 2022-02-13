namespace as03.Objects;

public class Vector3D
{
    public double x, y, z;

    public double Length => Math.Sqrt(x*x + y*y + z*z);

    public Vector3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vector3D VectorBetweenPoints(Point3D a, Point3D b)
    {
        var x_comp = a.x - b.x;
        var y_comp = a.y - b.y;
        var z_comp = a.z - b.z;

        return new Vector3D(x_comp, y_comp, z_comp);
    }
}