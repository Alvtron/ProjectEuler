using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ProjectEuler.Library;

namespace ProjectEuler.Problems
{
    public class Problem_0702 : Problem
    {
        private static readonly string QuestionFilePath = Path.Combine(Environment.CurrentDirectory, @"resources\problem_0702_question.txt");

        public Problem_0702()
            : base(702)
        {
        }

        public override string Question => File.ReadAllText(QuestionFilePath);
        
        public override Answer Answer => Answer.Empty;

        public override bool IsSolved => false;

        public override Answer Solve()
        {
            const int RADIUS = 123456789;

            // Create Hexagon

            var hexagon = new Dictionary<char, Point>();

            var a = RADIUS / 2d;
            var c = a / Math.Sin(30d * Math.PI / 180d);
            var b = c * Math.Cos(30d * Math.PI / 180d);

            hexagon['A'] = new Point(RADIUS, RADIUS + b);
            hexagon['B'] = new Point(RADIUS + a, RADIUS);
            hexagon['C'] = new Point(RADIUS + a + c, RADIUS);
            hexagon['D'] = new Point(RADIUS + 2 * c, RADIUS + b);
            hexagon['E'] = new Point(RADIUS + a + c, RADIUS + 2 * b);
            hexagon['F'] = new Point(RADIUS + a, RADIUS + 2 * b);

            // Create Triangle Map

            var triangleMap = new Dictionary<TriKey, int>();
            var upperTriangles = new HashSet<TriKey>();

            var triangleIndexer = 0;

            int top;

            for (top = 0; top < RADIUS; top++)
            {
                int left;

                for (left = 0; left < RADIUS + top; left++)
                {
                    var up = new TriKey(top, left, left + 2 - top);
                    triangleMap[up] = triangleIndexer++;
                    upperTriangles.Add(up);

                    var down = new TriKey(top, left, left + 3 - top);
                    triangleMap[down] = triangleIndexer++;
                }

                var lastUp = new TriKey(top, left, left + 2 - top);
                triangleMap[lastUp] = triangleIndexer++;
                upperTriangles.Add(lastUp);
            }

            while (top < RADIUS * 2)
            {
                int left;
                var shift = top % RADIUS;

                for (left = 0; left < (RADIUS * 2 - 1) - (top % RADIUS); left++)
                {
                    var down = new TriKey(top, left + shift, left);
                    triangleMap[down] = triangleIndexer++;

                    var up = new TriKey(top, left + 1 + shift, left);
                    triangleMap[up] = triangleIndexer++;
                }

                var lastDown = new TriKey(top, left, left);
                triangleMap[lastDown] = triangleIndexer++;

                top++;
            }

            foreach (var key in triangleMap.Keys)
            {
                Debug.WriteLine($"{key} => {triangleMap[key]}");
            }

            return 0;
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

        private readonly struct TriKey
        {
            private readonly int top;
            private readonly int left;
            private readonly int right;

            public TriKey(int top, int left, int right)
            {
                this.top = top;
                this.left = left;
                this.right = right;
            }

            public override string ToString()
            {
                return $"{this.top}, {this.left}, {this.right}";
            }
        }
    }
}
