using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{

    /// <summary>
    ///    A
    ///   / \
    ///  B - C
    /// </summary>
    internal struct Triangle
    {
        private Point m_a;
        private Point m_b;
        private Point m_c;

        public Point A
        {
            get => m_a;
        }

        public Point B
        {
            get => m_b;
        }

        public Point C
        {
            get => m_c;
        }

        public Point[] Points
        {
            get => new Point[3] { m_a, m_b, m_c };
        }

        public Point Centroid
        {
            get => (m_a + m_b + m_c) / 2;
        }

        public double Height
        {
            get => m_a.Y - m_b.Y;
        }

        public double Area
        {
            get => Math.Abs((m_a.X * (m_b.Y - m_c.Y) + m_b.X * (m_c.Y - m_a.Y) + m_c.X * (m_a.Y - m_b.Y)) / 2.0);
        }

        public Triangle(Point a, Point b, Point c)
        {
            m_a = a;
            m_b = b;
            m_c = c;
        }

        public Triangle(double x, double y, double length = 1)
        {
            m_a = new Point(x, y + (Math.Sqrt(3) / 3) * length);
            m_b = new Point(x - (length / 2d), y - (Math.Sqrt(3d) / 6d) * length);
            m_c = new Point(x + (length / 2d), y - (Math.Sqrt(3d) / 6d) * length);
        }

        public bool IsInside(Point point)
        {
            // Calculate area of triangle ABC
            var A = Area;

            // Calculate area of triangle PBC
            var A1 = new Triangle(point, m_b, m_c).Area;

            // Calculate area of triangle PAC
            var A2 = new Triangle(m_a, point, m_c).Area;

            // Calculate area of triangle PAB
            var A3 = new Triangle(m_a, m_b, point).Area;

            // Check if sum of A1, A2 and A3 is same as A
            return A == (A1 + A2 + A3);
        }

        public Triangle Rotate(double angle) => Rotate(Centroid, angle);

        public Triangle Rotate(Point origin, double angle)
        {
            var newA = new Point(
                x: origin.X + Math.Cos(angle) * (m_a.X - origin.X) - Math.Sin(angle) * (m_a.Y - origin.Y),
                y: origin.Y + Math.Sin(angle) * (m_a.X - origin.X) + Math.Cos(angle) * (m_a.Y - origin.Y));

            var newB = new Point(
                x: origin.X + Math.Cos(angle) * (m_b.X - origin.X) - Math.Sin(angle) * (m_b.Y - origin.Y),
                y: origin.Y + Math.Sin(angle) * (m_b.X - origin.X) + Math.Cos(angle) * (m_b.Y - origin.Y));

            var newC = new Point(
                x: origin.X + Math.Cos(angle) * (m_c.X - origin.X) - Math.Sin(angle) * (m_c.Y - origin.Y),
                y: origin.Y + Math.Sin(angle) * (m_c.X - origin.X) + Math.Cos(angle) * (m_c.Y - origin.Y));

            return new Triangle(newA, newB, newC);
        }
    }

    class Problem_0702_scrapped : IProblem<long>
    {
        private readonly Dictionary<Triangle, int> UpTriangles;
        private readonly Dictionary<Triangle, int> DownTriangles;
        private readonly HashSet<Triangle> UpperTriangles;

        private Dictionary<Triangle, int> Triangles
        {
            get => UpTriangles.Union(DownTriangles).ToDictionary(k => k.Key, v => v.Value);
        }

        public Problem_0702_scrapped(int n = 3)
        {
            UpTriangles = new Dictionary<Triangle, int>();
            DownTriangles = new Dictionary<Triangle, int>();

            var width = 1d;
            var halfWidth = width / 2d;
            var height = ((Math.Sqrt(3d) / 3d)) + ((Math.Sqrt(3d) / 6d));

            var triangleIndexes = (int)Math.Pow(n, n) * 2;

            for (var y = 0; y < n; y++)
            {
                var h = y * height;
                var indent = (width * (n / 2d)) - (y * halfWidth);

                for (var w = indent; w < (n * 2d) - indent; w += width)
                {
                    var downTriangle = new Triangle(
                        a: new Point(w + halfWidth, h + height),
                        b: new Point(w, h),
                        c: new Point(w + width, h));

                    var upTriangle = new Triangle(
                        a: new Point(w + halfWidth, h + height),
                        b: new Point(w, h),
                        c: new Point(w + width, h));

                    DownTriangles[downTriangle] = triangleIndexes--;
                    UpTriangles[upTriangle] = triangleIndexes--;
                }
            }

        }

        public string Question { get; }

        public long Answer()
        {
            foreach (var key in Triangles.Keys)
            {
                Debug.WriteLine($"{key} => {Triangles[key]}");
            }

            return 0;
        }
    }
}
