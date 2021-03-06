﻿using System;
using System.Collections.Generic;
using System.Numerics;
using static System.Numerics.Vector3;

namespace Raytracing
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/M%C3%B6ller%E2%80%93Trumbore_intersection_algorithm
    /// </summary>
    public static class TriangleRayIntersection
    {
        private static readonly Vector3? NoHit = null;
        private const float Epsilon = 0.0000001f;

        public static Vector3? Intersect(Ray ray, Triangle triangle)
        {
            Vector3 edge1 = triangle.B - triangle.A;
            Vector3 edge2 = triangle.C - triangle.A;

            (Vector3 origin, Vector3 direction) = ray;
            Vector3 h = Cross(direction, edge2);
            float a = Dot(edge1, h);

            if (a > -Epsilon && a < Epsilon)
            {
                return NoHit;
            }

            float f = 1.0f / a;
            Vector3 s = origin - triangle.A;
            float u = f * Dot(s, h);

            if (u < 0.0 || u > 1.0)
            {
                return NoHit;
            }

            Vector3 q = Cross(s, edge1);
            float v = f * Dot(direction, q);
            if (v < 0.0 || u + v > 1.0)
            {
                return NoHit;
            }

            float t = f * Dot(edge2, q);

            if (t > Epsilon)
            {
                return origin + direction * t;
            }

            return NoHit;
        }
    }
}
