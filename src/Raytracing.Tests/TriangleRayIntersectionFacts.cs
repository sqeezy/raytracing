using System.Collections.Generic;
using System.Numerics;
using Xunit;
using static Raytracing.Extensions;
using static System.Numerics.Vector3;

namespace Raytracing.Tests
{
    public class TriangleRayIntersectionFacts
    {
        private static readonly Vector3 A = V(0, 0, 0);
        private static readonly Vector3 B = V(10, 0, 0);
        private static readonly Vector3 C = V(0, 10, 0);
        private Triangle _triangle;
        private Vector3? _result;
        private Ray _ray;

        public static IEnumerable<object[]> RayVsLineData
        {
            get
            {
                yield return new object[] {V(0, 0, -1), V(1, 1, 0)};
                yield return new object[] {V(0, 0, 1), null};
            }
        }

        public static IEnumerable<object[]> CornerData
        {
            get
            {
                yield return new object[] {V(0, 0, 10), Normalize(A - V(0, 0, 10)), A};
                yield return new object[] {V(17, 6, -100), Normalize(B - V(17, 6, -100)), B};
                yield return new object[] {V(-111, 222, 333), Normalize(C - V(-111, 222, 333)), C};
            }
        }

        [Theory]
        [MemberData(nameof(RayVsLineData))]
        public void It_can_distinguish_between_ray_and_line_hit(Vector3 direction, Vector3? expectedHit)
        {
            GivenTriangle();
            GivenRay(V(1, 1, 10), direction);
            WhenIntersecting();

            ThenResultMatches(expectedHit);
        }

        [Theory]
        [MemberData(nameof(CornerData))]
        public void It_hits_the_corners(Vector3 origin, Vector3 direction, Vector3? expectedHit)
        {
            GivenTriangle();
            GivenRay(origin, direction);
            WhenIntersecting();

            ThenResultMatches(expectedHit);
        }

        private void ThenResultMatches(Vector3? expectedHit)
        {
            Assert.True(_result.HasValue == expectedHit.HasValue,
                        expectedHit.HasValue
                            ? "There was no hit even though expected."
                            : "There was a hit even though none was expected");
            if (expectedHit.HasValue)
            {
                Assert.True(expectedHit.Value.IsCloseTo(_result.Value));
            }
        }

        private void WhenIntersecting()
        {
            _result = TriangleRayIntersection.Intersect(_ray, _triangle);
        }

        private void GivenRay(Vector3 origin, Vector3 direction)
        {
            _ray = new Ray(origin, direction);
        }

        private void GivenTriangle()
        {
            _triangle = new Triangle(new[] {A, B, C});
        }
    }
}
