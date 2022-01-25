
namespace polar_coordinates_utils;

public static class PolarCoordinateUtils
{
    public static double Atan2(double y, double x)
    {
        return x switch
        {
            0 when y > 0 => Math.PI / 2,
            0 when y < 0 => -Math.PI / 2,
            > 0 => Math.Atan(y / x),
            < 0 when y >= 0 => Math.Atan(y / x) + (2 * Math.PI),
            < 0 when y < 0 => Math.Atan(y / x) - (2 * Math.PI),
            _ => 0
        };
    }

    private static void CanonizeTheta(double t, out double res)
    {
        const double floor = -Math.PI;
        const double roof = Math.PI;

        while (t is <= floor or > roof)
        {
            if (t <= floor)
            {
                t += Math.PI;
            }

            if (t > roof)
            {
                t -= Math.PI;
            }
        }

        res = t;
    }
    public static double RadianToDegrees(double radian)
    {
        return (radian*180/Math.PI);
    }

    public static double[] CalculateThetas(double[] x, double[] y)
    {
        var t = new double[x.Length];

        for (var i = 0; i < x.Length; i++)
        {
            t[i] = PolarCoordinateUtils.Atan2(y[i], x[i]);
            PolarCoordinateUtils.CanonizeTheta(t[i], out t[i]);
        }

        return t;
    }
}

