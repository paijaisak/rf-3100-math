using as03.Objects;
using NUnit.Framework;

namespace math_tests
{
    public class TestPlanes
    {
        [Test]
        public void IsPointOnPlane()
        {
            var normal = new Vector3D(5, 6, -8);
            const double d = 23;

            var a = new Point3D(0, 1, 8);
            var b = new Point3D(5, 1, 1);

            var plane = new Plane(normal, d);

            Assert.IsFalse(a.IsOnPlane(plane));
            Assert.IsTrue(b.IsOnPlane(plane));
        }
    }
}
