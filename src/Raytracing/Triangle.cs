using System.Collections.Generic;
using System.Numerics;

namespace Raytracing
{
    public record Triangle(IReadOnlyList<Vector3> Points)
    {
        public Vector3 A { get; } = Points[0];
        public Vector3 B { get; } = Points[1];
        public Vector3 C { get; } = Points[2];

        public Vector3 Normal { get; } = Vector3.Cross(Points[0], Points[1]);
    }
}
