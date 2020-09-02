using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    internal struct TriKey
    {
        private int m_top;
        private int m_left;
        private int m_right;

        public TriKey(int top, int left, int right)
        {
            m_top = top;
            m_left = left;
            m_right = right;
        }

        public override string ToString()
        {
            return $"{m_top}, {m_left}, {m_right}";
        }
    }

    class Problem_0702 : IProblem<long>
    {
        private readonly Dictionary<TriKey, int> TriangleMap;
        private readonly HashSet<TriKey> UpperTriangles;
        private readonly Dictionary<char, Point> Hexagon;

        public Problem_0702(int radius = 123456789)
        {
            // Create Hexagon

            Hexagon = new Dictionary<char, Point>();

            var a = radius / 2d;
            var c = a / Math.Sin(30d * Math.PI / 180d);
            var b = c * Math.Cos(30d * Math.PI / 180d);

            Hexagon['A'] = new Point(radius, radius + b);
            Hexagon['B'] = new Point(radius + a, radius);
            Hexagon['C'] = new Point(radius + a + c, radius);
            Hexagon['D'] = new Point(radius + (2 * c), radius + b);
            Hexagon['E'] = new Point(radius + a + c, radius + (2 * b));
            Hexagon['F'] = new Point(radius + a, radius + (2 * b));

            // Create Triangle Map

            TriangleMap = new Dictionary<TriKey, int>();
            UpperTriangles = new HashSet<TriKey>();

            var triangleIndexer = 0;

            int top;

            for (top = 0; top < radius; top++)
            {
                int left;

                for (left = 0; left < radius + top; left++)
                {
                    var up = new TriKey(top, left, left + 2 - top);
                    TriangleMap[up] = triangleIndexer++;
                    UpperTriangles.Append(up);
                    
                    var down = new TriKey(top, left, left + 3 - top);
                    TriangleMap[down] = triangleIndexer++;
                }

                var lastUp = new TriKey(top, left, left + 2 - top);
                TriangleMap[lastUp] = triangleIndexer++;
                UpperTriangles.Append(lastUp);
            }

            while (top < radius * 2)
            {
                int left;
                var shift = top % radius;

                for (left = 0; left < (radius * 2 - 1) - (top % radius); left++)
                {
                    var down = new TriKey(top, left + shift, left);
                    TriangleMap[down] = triangleIndexer++;

                    var up = new TriKey(top, left + 1 + shift, left);
                    TriangleMap[up] = triangleIndexer++;
                }

                var lastDown = new TriKey(top, left, left);
                TriangleMap[lastDown] = triangleIndexer++;

                top++;
            }
        }

        private static Point CartesianPositionToDiagonalPosition(Point position)
        {
            var n = 3;

            var pointA = new Point(0.0, 0.0);
            var pointB = position;
            var angleC = 60.0;
            var angleB = Point.Angle(pointA, pointB);
            var angleA = 180.0 - 60.0 - angleB;
            var lengthAB = Point.Distance(pointA, pointB);

            return new Point(0, 0);
        }

        public string Question { get; }

        public long Answer()
        {
            foreach (var key in TriangleMap.Keys)
            {
                Debug.WriteLine($"{key} => {TriangleMap[key]}");
            }

            return 0;
        }
    }
}
