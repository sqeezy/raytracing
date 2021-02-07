using System.Collections.Generic;
using System.Numerics;
using Xunit;
using static Raytracing.Extensions;

namespace Raytracing.Tests
{
    public class TriangleRayIntersectionFacts
    {
        private Vector3 _a;
        private Vector3 _b;
        private Vector3 _c;
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

        [Theory]
        [MemberData(nameof(RayVsLineData))]
        public void It_can_distinguish_between_ray_and_line_hit(Vector3 direction, Vector3? expectedHit)
        {
            GivenTriangle();
            GivenRay(direction);

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
                Assert.Equal(expectedHit, _result);
            }
        }

        private void WhenIntersecting()
        {
            _result = TriangleRayIntersection.Intersect(_ray, _triangle);
        }

        private void GivenRay(Vector3 direction)
        {
            _ray = new Ray(V(1, 1, 10), direction);
        }

        private void GivenTriangle()
        {
            _a = V(0, 0, 0);
            _b = V(10, 0, 0);
            _c = V(0, 10, 0);

            _triangle = new Triangle(new[] {_a, _b, _c});
        }
    }
}
