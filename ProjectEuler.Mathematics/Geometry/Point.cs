﻿namespace ProjectEuler.Mathematics.Geometry;

internal readonly struct Point(double x, double y)
{
    public double X { get; } = x;

    public double Y { get; } = y;

    public double Magnitude => Math.Sqrt(this.X * this.X + this.Y * this.Y);

    public static double DotProduct(Point a, Point b)
        => a.X * b.X + a.Y * b.Y;

    public static double Angle(Point a, Point b)
        => Math.Acos(DotProduct(a, b) / (a.Magnitude * b.Magnitude));

    public static double Distance(Point a, Point b)
        => Math.Sqrt(Math.Pow(b.X - a.X, 2.0) + Math.Pow(b.Y - a.Y, 2.0));

    public static Point operator +(Point a, Point b)
        => new(a.X + b.X, a.Y + b.Y);

    public static Point operator -(Point a, Point b)
        => new(a.X - b.X, a.Y - b.Y);

    public static Point operator *(Point a, Point b)
        => new(a.X * b.X, a.Y * b.Y);

    public static Point operator /(Point a, Point b)
        => new(a.X / b.X, a.Y / b.Y);

    public static Point operator +(Point a, double scalar)
        => new(a.X + scalar, a.Y + scalar);

    public static Point operator -(Point a, double scalar)
        => new(a.X - scalar, a.Y - scalar);

    public static Point operator *(Point a, double scalar)
        => new(a.X * scalar, a.Y * scalar);

    public static Point operator /(Point a, double scalar)
        => new(a.X / scalar, a.Y / scalar);
}