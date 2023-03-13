Dictionary<string, string> Results = new();
Results.Add("X", "Lose");
Results.Add("Y", "Draw");
Results.Add("Z", "Win");

//getting fancy trying some switch expression
//one to get the score given the player and opponent move
int getScore(Moves player, Moves opponent) => (player, opponent) switch
{
    { player: Moves.Rock,       opponent: Moves.Scissors }  or
    { player: Moves.Paper,      opponent: Moves.Rock }      or
    { player: Moves.Scissors,   opponent: Moves.Paper }     => 6,
    { player: Moves.Rock,       opponent: Moves.Rock }      or
    { player: Moves.Paper,      opponent: Moves.Paper }     or
    { player: Moves.Scissors,   opponent: Moves.Scissors }  => 3,
    _                                                       => 0
};

//and one to get the need move given the opponent move and the needed score
int getMove(Moves opponent, Scores score) => (opponent, score) switch
{
    { opponent: Moves.Rock,     score: Scores.Draw }    or
    { opponent: Moves.Paper,    score: Scores.Lose }    or
    { opponent: Moves.Scissors, score: Scores.Win }     => 1,
    { opponent: Moves.Rock,     score: Scores.Win }     or
    { opponent: Moves.Paper,    score: Scores.Draw }    or
    { opponent: Moves.Scissors, score: Scores.Lose }    => 2,
    { opponent: Moves.Rock,     score: Scores.Lose }    or
    { opponent: Moves.Paper,    score: Scores.Win }     or
    { opponent: Moves.Scissors, score: Scores.Draw }    => 3,
    _                                                   => 0
};

void Part1()
{
    string input = File.ReadAllText("Input.txt");

    Dictionary<string, string> values = new();
    values.Add("A", "Rock");
    values.Add("X", "Rock");
    values.Add("B", "Paper");
    values.Add("Y", "Paper");
    values.Add("C", "Scissors");
    values.Add("Z", "Scissors");

    int total = 0;

    //pretty easy: iterate, get score, add to total as the problem says
    foreach (var game in input.Split("\r\n"))
    {
        Moves opponent = (Moves)Enum.Parse(typeof(Moves), values[game.Split(" ")[0]]);
        Moves me = (Moves)Enum.Parse(typeof(Moves), values[game.Split(" ")[1]]);
        int score = getScore(me, opponent);

        total += (int)me + score;
    }

    File.WriteAllText("Output1.txt", total.ToString());
}

void Part2()
{
    string input = File.ReadAllText("Input.txt");

    Dictionary<string, string> values = new();
    values.Add("A", "Rock");
    values.Add("B", "Paper");
    values.Add("C", "Scissors");

    int total = 0;

    //that's as easy as part one, just get the move instead of the score
    foreach (var game in input.Split("\r\n"))
    {
        Moves opponent = (Moves)Enum.Parse(typeof(Moves), values[game.Split(" ")[0]]);
        Scores result = (Scores)Enum.Parse(typeof(Scores), Results[game.Split(" ")[1]]);

        total += ((int)result) + getMove(opponent, result);
    }

    File.WriteAllText("Output2.txt", total.ToString());
}

Part1();
Part2();

public enum Moves
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum Scores
{
    Lose = 0,
    Draw = 3,
    Win = 6
}
