namespace ProjectEuler.Library
{
    internal readonly struct Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public Position Right(int steps = 1)
            => new(this.X + steps, this.Y);

        public Position Left(int steps = 1)
            => new(this.X - steps, this.Y);

        public Position Up(int steps = 1)
            => new(this.X, this.Y - steps);

        public Position Down(int steps = 1)
            => new(this.X, this.Y + steps);

        public static Position operator +(Position a, Position b)
            => new(a.X + b.X, a.Y + b.Y);
        
        public static Position operator -(Position a, Position b)
            => new(a.X - b.X, a.Y - b.Y);

        public static Position operator *(Position a, Position b)
            => new(a.X * b.X, a.Y * b.Y);

        public static Position operator /(Position a, Position b)
            => new(a.X / b.X, a.Y / b.Y);

        public static Position operator +(Position a, int scalar)
            => new(a.X + scalar, a.Y + scalar);

        public static Position operator -(Position a, int scalar)
            => new(a.X - scalar, a.Y - scalar);

        public static Position operator *(Position a, int scalar)
            => new(a.X * scalar, a.Y * scalar);

        public static Position operator /(Position a, int scalar)
            => new(a.X / scalar, a.Y / scalar);
    }
}