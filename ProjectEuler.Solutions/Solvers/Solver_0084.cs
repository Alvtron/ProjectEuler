using ProjectEuler.Solutions.Answers;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0084 : ISolver
{
    private static readonly Random Random = new();

    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var board = Board.CreateStandard();
        var positionFrequencies = new int[40];

        var player = new Player();
        const int SIMULATION_STEPS = 10_000_000;

        for (var i = 0; i < SIMULATION_STEPS; i++)
        {
            player.Move(board);
            positionFrequencies[player.Position]++;
        }

        var mostVisitedSquares = positionFrequencies
            .Select((count, index) => (Index: index, Count: count))
            .OrderByDescending(x => x.Count)
            .Take(3)
            .Select(x => x.Index.ToString("D2"))
            .Aggregate((a, b) => a + b);

        return Task.FromResult<Answer>(mostVisitedSquares);
    }

    private sealed class Player
    {
        private int consecutiveDoubles;

        public int Position { get; private set; }

        public void Move(Board board)
        {
            var (roll, isDouble) = RollDice();
            if (isDouble)
            {
                consecutiveDoubles++;
                if (consecutiveDoubles == 3)
                {
                    Position = board.GoToJail();
                    consecutiveDoubles = 0;
                    return;
                }
            }
            else
            {
                consecutiveDoubles = 0;
            }

            Position = (Position + roll) % 40;
            Position = board.ResolvePosition(Position);
        }

        private static (int Roll, bool IsDouble) RollDice()
        {
            var die1 = Random.Next(1, 5);
            var die2 = Random.Next(1, 5);
            return (die1 + die2, die1 == die2);
        }
    }

    private sealed class Board
    {
        private readonly int[] communityChestDeck;
        private readonly int[] chanceDeck;
        private int communityChestIndex;
        private int chanceIndex;

        private Board()
        {
            // Community Chest (16 cards, only 2 affect movement)
            communityChestDeck = Enumerable.Range(0, 16).OrderBy(_ => Random.Next()).ToArray();

            // Chance (10 cards, 6 affect movement)
            chanceDeck = Enumerable.Range(0, 10).OrderBy(_ => Random.Next()).ToArray();
        }

        public static Board CreateStandard() => new();

        public int ResolvePosition(int position)
        {
            return position switch
            {
                30 => GoToJail(), // "Go to Jail" square
                2 or 17 or 33 => DrawCommunityChest(position),
                7 or 22 or 36 => DrawChance(position),
                _ => position
            };
        }

        public int GoToJail() => 10; // Jail index

        private int DrawCommunityChest(int position)
        {
            var card = communityChestDeck[communityChestIndex++ % 16];
            return card switch
            {
                0 => 0,  // "Advance to GO"
                1 => GoToJail(),
                _ => position
            };
        }

        private int DrawChance(int position)
        {
            var card = chanceDeck[chanceIndex++ % 10];
            return card switch
            {
                0 => 0,   // "Advance to GO"
                1 => 10,  // "Go to Jail"
                2 => 11,  // "Go to C1"
                3 => 24,  // "Go to E3"
                4 => 39,  // "Go to H2"
                5 => 5,   // "Go to R1"
                6 => NextRailway(position),
                7 => NextRailway(position),
                8 => NextUtility(position),
                9 => (position - 3 + 40) % 40, // "Go back 3 spaces"
                _ => position
            };
        }

        private static int NextRailway(int position)
        {
            return position switch
            {
                < 5 => 5,
                < 15 => 15,
                < 25 => 25,
                < 35 => 35,
                _ => 5
            };
        }

        private static int NextUtility(int position)
        {
            return position < 12 || position >= 28 ? 12 : 28;
        }
    }
}
