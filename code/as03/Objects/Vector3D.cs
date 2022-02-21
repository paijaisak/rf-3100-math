namespace as03.Objects;

public class Vector3D
{
    public double x;
    public double y;
    public double z;

    public double Length => Math.Sqrt(x*x + y*y + z*z);

    public Vector3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // ASSERT EQUALS OPERATOR
    public static bool operator ==(Vector3D u, Vector3D v)
    {
        return Math.Abs(u.x - v.x) < 0.0001 &&
               Math.Abs(u.y - v.y) < 0.0001 &&
               Math.Abs(u.z - v.z) < 0.0001;
    }

    protected bool Equals(Vector3D other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Vector3D) obj);
    }

    public static bool operator !=(Vector3D u, Vector3D v)
    {
        return !(u == v);
    }

    // CASTING OPERATOR
    public static explicit operator Point3D(Vector3D v)
    {
        return new Point3D(v.x, v.y, v.z);
    }

    // MULTIPLICATION WITH SCALAR
    public static Vector3D operator *(Vector3D u, double n)
    {
        return new Vector3D(u.x * n, u.y * n, u.z * n);
    }

    public static Vector3D operator *(double n, Vector3D u)
    {
        return u * n;
    }

    // DIVISION OPERATOR
    public static Vector3D operator /(Vector3D u, double n)
    {
        return new Vector3D(u.x / n, u.y / n, u.z / n);
    }

    // SUBTRACTION OPERATOR
    public static Vector3D operator -(Vector3D u, Vector3D v)
    {
        return new Vector3D(u.x - v.x, u.y - v.y, u.z - v.z);
    }
    
    // ADDITION OPERATOR
    public static Vector3D operator +(Vector3D u, Vector3D v)
    {
        return new Vector3D(u.x + v.x, u.y + v.y, u.z + v.z);
    }

    // DOT PRODUCT WITH * OPERATOR
    public static double operator *(Vector3D u, Vector3D v)
    {
        return (u.x * v.x) + (u.y * v.y) + (u.z * v.z);
    }

    public override string ToString()
    {
        return "[" + x + ", " + y + ", " + z + "]";
    }

    public void Normalize()
    {
        x /= this.Length;
        y /= this.Length;
        z /= this.Length;
    }

    public static Vector3D Cross(Vector3D left, Vector3D right)
    { 
        var x = left.y * right.z - left.z * right.y;
        var y = left.z * right.x - left.x * right.z;
        var z = left.x * right.y - left.y * right.x;

        return new Vector3D(x, y, z);
    }
    
    public Vector3D Cross(Vector3D right)
    {
        var _x = y * right.z - z * right.y;
        var _y = z * right.x - x * right.z;
        var _z = x * right.y - y * right.x;

        return new Vector3D(_x, _y, _z);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, z);
    }
}
