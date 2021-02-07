using System.Collections.Generic;
using System.Numerics;

namespace Raytracing
{
    public class Triangle
    {
        private readonly IReadOnlyList<Vector3> _points;

        public Triangle(IReadOnlyList<Vector3> points)
        {
            _points = points;
        }

        public Vector3 A => _points[0];
        public Vector3 B => _points[1];
        public Vector3 C => _points[2];
        public IReadOnlyList<Vector3> Points => _points;
    }
}
