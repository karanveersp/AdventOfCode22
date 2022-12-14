namespace AdventOfCode22;

using System.Linq;

public static class Day2
{
    static readonly string[] OpponentHands = { "A", "B", "C" };
    static readonly string[] SelfHands = { "X", "Y", "Z" };
    static readonly int WinModifier = 6;
    static readonly int DrawModifier = 3;
    static readonly int LoseModifier = 0;

    static readonly IReadOnlyDictionary<int, int> DefeatedByMap = new Dictionary<int, int>() {
        {0, 1},
        {1, 2},
        {2, 0}
    };
    static readonly IReadOnlyDictionary<int, int> WinsAgainstMap = DefeatedByMap.ToDictionary(x => x.Value, x => x.Key);

    record Player(string Hand);
    record Self(string Hand) : Player(Hand);
    record Opponent(string Hand) : Player(Hand);

    private static int GetHandScore(Player p)
    {
        if (OpponentHands.Contains(p.Hand))
        {
            return Array.IndexOf(OpponentHands, p.Hand) + 1;
        }
        return Array.IndexOf(SelfHands, p.Hand) + 1;
    }

    private static Player? PlayRound(Player self, Player opponent)
    {
        int opponnentHandVal = Array.IndexOf(OpponentHands, opponent.Hand);
        int selfHandVal = Array.IndexOf(SelfHands, self.Hand);
        int diff = selfHandVal - opponnentHandVal;
        switch (diff)
        {
            case 1:
                return self;
            case 2:
                return opponent;
            case -1:
                return opponent;
            case -2:
                return self;
            default:
                return null; // draw
        }
    }

    private static Self GetHandForOutcome(string outcome, Player opponent)
    {
        int opponnentHandVal = Array.IndexOf(OpponentHands, opponent.Hand);
        int index = outcome switch
        {
            "X" => WinsAgainstMap[opponnentHandVal],
            "Y" => opponnentHandVal,
            _ => DefeatedByMap[opponnentHandVal]
        };
        return new Self(SelfHands[index]);
    }

    public static void Play()
    {
        var lines = Util.GetDataLines("Day2.txt");
        int myScore = lines
            .Select(line =>
            {
                var hands = line.Split(' ');
                Opponent opponent = new Opponent(hands[0]);
                Self self = new Self(hands[1]);
                return new { roundWinner = PlayRound(self, opponent), selfHandScore = GetHandScore(self) };
            })
            .Select(result =>
                result.roundWinner switch
                {
                    Self _ => WinModifier + result.selfHandScore,
                    Opponent _ => LoseModifier + result.selfHandScore,
                    _ => DrawModifier + result.selfHandScore
                })
            .Sum();

        Console.WriteLine($"Following the first strategy, I win with {myScore} points.");
    }

    public static void PlayPart2()
    {
        var lines = Util.GetDataLines("Day2.txt");
        int myScore = lines
            .Select(line =>
            {
                var hands = line.Split(' ');
                Opponent opponent = new Opponent(hands[0]);
                string outcome = hands[1];
                Self self = GetHandForOutcome(outcome, opponent);
                return new { roundWinner = PlayRound(self, opponent), selfHandScore = GetHandScore(self) };
            })
            .Select(result =>
                result.roundWinner switch
                {
                    Self _ => WinModifier + result.selfHandScore,
                    Opponent _ => LoseModifier + result.selfHandScore,
                    _ => DrawModifier + result.selfHandScore
                })
            .Sum();

        Console.WriteLine($"Following the second strategy, I win with {myScore} points.");
    }
}
