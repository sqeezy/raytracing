using System.Numerics;
using static System.Numerics.Vector3;

namespace Raytracing
{
    public static class Extensions
    {
        public static Vector3 V(float x, float y, float z) => new(x, y, z);
        public static bool IsCloseTo(this Vector3 v1, Vector3 v2) => (v1 - v2).LengthSquared() < 1e-8;
    }
}
