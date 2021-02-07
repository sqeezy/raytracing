using System.Collections.Generic;
using System.Numerics;

namespace Raytracing
{
    public record Triangle(IReadOnlyList<Vector3> Points)
    {
        public Vector3 A => Points[0];
        public Vector3 B => Points[1];
        public Vector3 C => Points[2];

        public Vector3 Normal => Vector3.Cross(A, B);
    }
}
