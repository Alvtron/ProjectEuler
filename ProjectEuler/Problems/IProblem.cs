using System;

namespace ProjectEuler.Problems
{
    public interface IProblem
    {
        public int Number { get; }

        public string Question { get; }

        public Answer Answer { get; }

        public bool IsSolved { get; }

        public Answer Solve();
    }

    public abstract class Problem : IProblem
    {
        protected Problem(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The problem number must be a positive integer.", nameof(number));
            }

            this.Number = number;
        }

        public int Number { get; }

        public abstract string Question { get; }

        public abstract Answer Answer { get; }

        public abstract bool IsSolved { get; }

        public abstract Answer Solve();
    }
}
