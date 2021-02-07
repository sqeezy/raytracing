using System;
using System.Collections.Generic;
using System.Numerics;
using static System.Numerics.Vector3;

namespace Raytracing
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm#:~:text=The%20M%C3%B6ller%E2%80%93Trumbore%20ray%2Dtriangle,the%20plane%20containing%20the%20triangle.
    /// </summary>
    public static class TriangleRayIntersection
    {
        private static readonly Vector3? NoHit = null;
        private const float Epsilon = 0.0000001f;

        public static Vector3? Intersect(Ray ray, Triangle triangle)
        {
            Vector3 edge1 = triangle.B - triangle.A;
            Vector3 edge2 = triangle.C - triangle.A;

            Vector3 h = Cross(ray.Direction, edge2);
            float a = Dot(edge1, h);

            if (a > -Epsilon && a < Epsilon)
            {
                return NoHit;
            }

            float f = 1.0f / a;
            Vector3 s = ray.Origin - triangle.A;
            float u = f * Dot(s, h);

            if (u < 0.0 || u > 1.0)
            {
                return NoHit;
            }

            Vector3 q = Cross(s, edge1);
            float v = f * Dot(ray.Direction, q);
            if (v < 0.0 || u + v > 1.0)
            {
                return NoHit;
            }

            float t = f * Dot(edge2, q);

            if (t > Epsilon)
            {
                return ray.Origin + ray.Direction * t;
            }

            return NoHit;
        }
    }
}
