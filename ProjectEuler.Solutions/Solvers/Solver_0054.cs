using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0054 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var lines = Resource_0054.PokerHands.Split(Environment.NewLine);

        var pokerHandComparer = new PokerHandComparer();
        var count = 0;
        foreach (var line in lines)
        {
            var firstHand = ParseFirstHand(line);
            var secondHand = ParseSecondHand(line);

            if (pokerHandComparer.Compare(firstHand, secondHand) > 0)
            {
                count++;
            }
        }

        return Task.FromResult<Answer>(count);
    }

    private static Hand ParseFirstHand(string hand)
    {
        return new Hand(hand[..14]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseCard).ToArray());
    }

    private static Hand ParseSecondHand(string hand)
    {
        return new Hand(hand[15..]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseCard).ToArray());
    }

    private static Card ParseCard(string card)
    {
        var rank = ParseRank(card[0]);
        var suit = ParseSuit(card[1]);
        return new Card(rank, suit);
    }

    private static CardValue ParseRank(char rank) => rank switch
    {
        '2' => CardValue.Two,
        '3' => CardValue.Three,
        '4' => CardValue.Four,
        '5' => CardValue.Five,
        '6' => CardValue.Six,
        '7' => CardValue.Seven,
        '8' => CardValue.Eight,
        '9' => CardValue.Nine,
        'T' => CardValue.Ten,
        'J' => CardValue.Jack,
        'Q' => CardValue.Queen,
        'K' => CardValue.King,
        'A' => CardValue.Ace,
        _ => throw new ArgumentException("Invalid rank.")
    };

    private static CardSuit ParseSuit(char suit) => suit switch
    {
        'H' => CardSuit.Heart,
        'D' => CardSuit.Diamond,
        'C' => CardSuit.Club,
        'S' => CardSuit.Spade,
        _ => throw new ArgumentException("Invalid suit.")
    };

    private readonly record struct Card(CardValue CardValue, CardSuit CardSuit);

    private readonly record struct Hand(Card[] Cards);

    private enum CardValue : byte
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    private enum CardSuit : byte
    {
        Heart = 1,
        Diamond = 2,
        Club = 3,
        Spade = 4
    }

    private enum HandRank : byte
    {
        HighCard = 1,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    private sealed class PokerHandComparer : IComparer<Hand>
    {
        public int Compare(Hand firstHand, Hand secondHand)
        {
            var firstHandRank = GetHandRank(firstHand);
            var secondHandRank = GetHandRank(secondHand);

            return firstHandRank.RankType != secondHandRank.RankType 
                ? firstHandRank.RankType.CompareTo(secondHandRank.RankType) 
                : CompareHighCards(firstHandRank.HighCards, secondHandRank.HighCards);
        }

        private static (HandRank RankType, IEnumerable<Card> HighCards) GetHandRank(Hand hand)
        {
            var cards = hand.Cards.OrderByDescending(c => c.CardValue).ToArray();

            if (IsRoyalFlush(cards))
                return (HandRank.RoyalFlush, cards);

            if (IsStraightFlush(cards))
                return (HandRank.StraightFlush, cards);

            if (IsFourOfAKind(cards, out var fourOfAKindHighCards))
                return (HandRank.FourOfAKind, fourOfAKindHighCards);

            if (IsFullHouse(cards, out var fullHouseHighCards))
                return (HandRank.FullHouse, fullHouseHighCards);

            if (IsFlush(cards))
                return (HandRank.Flush, cards);

            if (IsStraight(cards))
                return (HandRank.Straight, cards);

            if (IsThreeOfAKind(cards, out var threeOfAKindHighCards))
                return (HandRank.ThreeOfAKind, threeOfAKindHighCards);

            if (IsTwoPair(cards, out var twoPairHighCards))
                return (HandRank.TwoPair, twoPairHighCards);

            if (IsOnePair(cards, out var onePairHighCards))
                return (HandRank.OnePair, onePairHighCards);

            return (HandRank.HighCard, cards);
        }

        private static bool IsRoyalFlush(Card[] cards)
        {
            return IsFlush(cards) && IsStraight(cards) && cards[0].CardValue == CardValue.Ace;
        }

        private static bool IsStraightFlush(Card[] cards)
        {
            return IsFlush(cards) && IsStraight(cards);
        }

        private static bool IsFourOfAKind(Card[] cards, out IEnumerable<Card> highCards)
        {
            var rankGroups = cards.GroupBy(c => c.CardValue).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToArray();
            if (rankGroups[0].Count() != 4)
            {
                highCards = [];
                return false;
            }

            highCards = rankGroups.SelectMany(g => g);
            return true;
        }

        private static bool IsFullHouse(Card[] cards, out IEnumerable<Card> highCards)
        {
            var rankGroups = cards.GroupBy(c => c.CardValue).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToArray();
            if (rankGroups[0].Count() == 3 && rankGroups[1].Count() == 2)
            {
                highCards = rankGroups.SelectMany(g => g);
                return true;
            }
            highCards = [];
            return false;
        }

        private static bool IsFlush(Card[] cards)
        {
            return cards.All(c => c.CardSuit == cards[0].CardSuit);
        }

        private static bool IsStraight(Card[] cards)
        {
            for (var i = 0; i < cards.Length - 1; i++)
            {
                if (cards[i].CardValue - cards[i + 1].CardValue != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsThreeOfAKind(Card[] cards, out IEnumerable<Card> highCards)
        {
            var rankGroups = cards.GroupBy(c => c.CardValue).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToArray();
            if (rankGroups[0].Count() == 3)
            {
                highCards = rankGroups.SelectMany(g => g);
                return true;
            }
            highCards = [];
            return false;
        }

        private static bool IsTwoPair(Card[] cards, out IEnumerable<Card> highCards)
        {
            var rankGroups = cards.GroupBy(c => c.CardValue).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToArray();
            if (rankGroups[0].Count() == 2 && rankGroups[1].Count() == 2)
            {
                highCards = rankGroups.SelectMany(g => g);
                return true;
            }
            highCards = [];
            return false;
        }

        private static bool IsOnePair(Card[] cards, out IEnumerable<Card> highCards)
        {
            var rankGroups = cards.GroupBy(c => c.CardValue).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToArray();
            if (rankGroups[0].Count() == 2)
            {
                highCards = rankGroups.SelectMany(g => g);
                return true;
            }
            highCards = [];
            return false;
        }

        private static int CompareHighCards(IEnumerable<Card> xHighCards, IEnumerable<Card> yHighCards)
        {
            return xHighCards.Zip(yHighCards)
                .Select((versus => versus.First.CardValue.CompareTo(versus.Second.CardValue)))
                    .FirstOrDefault(comparison => comparison != 0);
        }
    }
}