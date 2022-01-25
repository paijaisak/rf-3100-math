
using polar_coordinates_utils;

var xValues = new double[]
{
    10, -12, 0, -3, 0, -5280
};

var yValues = new double[]
{
    20, -5, 4.5, 4, 0, 0
};

var theta = PolarCoordinateUtils.CalculateThetas(xValues, yValues);

for (var i = 0; i < theta.Length; i++)
{
    PrintCalculations(xValues[i], yValues[i], theta[i]);
}

static void PrintCalculations(double x, double y, double t)
{
    Console.WriteLine("Atan2({0}, {1}) = {2}°\n",
        x, y, Math.Round(PolarCoordinateUtils.RadianToDegrees(t), 2));
}



