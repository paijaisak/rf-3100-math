namespace as03.Objects;

public class Plane3D
{
    public Vector3D normal;
    public double d;
    public Vector3D[] points;

    public Plane3D(Vector3D normal, double d)
    {
        this.normal = normal;
        this.d = d;
    }

    public Vector3D Normal
    {
        get
        {
            Vector3D res;
            return normal;
        }

        set
        {
            normal = value;
        }
    }
}