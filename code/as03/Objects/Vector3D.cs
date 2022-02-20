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

    // CASTING OPERATOR
    public static explicit operator Point3D(Vector3D v)
    {
        return new Point3D(v.x, v.y, v.z);
    }

    public static Vector3D operator -(Vector3D u, Vector3D v)
    {
        return new Vector3D(u.x - v.x, u.y - v.y, u.z - v.z);
    }

    public override string ToString()
    {
        return "[" + x + ", " + y + ", " + z + "]";
    }

    public void Normalize()
    {
        this.x /= this.Length;
        this.y /= this.Length;
        this.z /= this.Length;
    }

    public static Vector3D Cross(Vector3D left, Vector3D right)
    { 
        var x = left.y * right.z - left.z * right.y;
        var y = left.z * right.x - left.x * right.z;
        var z = left.x * right.y - left.y * right.x;

        return new Vector3D(x, y, z);
    }
}