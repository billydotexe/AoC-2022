using AdventUtility;
using System.Linq;

void Part1()
{
    List<string> input = File.ReadAllText("Input.txt").Split("\r\n").ToList();
    int separator = input.Where(x => x.StartsWith("m")).Select(x => input.IndexOf(x)).First();
    List<string> start = input.Take(separator).ToList().RemoveEmpty().SkipLast(1).ToList();
    start.Reverse();
    List<string> inMoves = input.Skip(separator-1).ToList().RemoveEmpty();
    //----setup workplace---
    for(int i = 0; i < start.Count; i++)
    {
        start[i] = start[i].Replace("    ", "*").Replace(" ", "").Replace("[", "").Replace("]", "");
    }
    int stacks = start[0].Length;
    List<string> workplace = new();
    for (int i = 0; i < stacks; i++) workplace.Add(string.Empty);
    
    foreach (var line in start)
    {
        for(int i = 0; i < stacks; i++)
        {
            if(line[i] != '*') workplace[i] += line[i];
        }
    }
    //----end setup workplace----
    //----setup moves----
    List<(int, int, int)> moves = new();
    foreach(string s in inMoves)
    {
        string[] tmp = s.Split(" ");
        moves.Add((int.Parse(tmp[1]), int.Parse(tmp[3]), int.Parse(tmp[5])));
    }
    //----end setup moves----

    foreach((int move, int from, int to) move in moves)
    {
        for(int i = 0; i < move.move; i++)
        {
            workplace[move.to-1] += workplace[move.from-1].Last();
            workplace[move.from - 1] = workplace[move.from-1].Substring(0, workplace[move.from - 1].Length-1);
        }
    }

    File.WriteAllText("Output1.txt", String.Join("", workplace.Select(x => x.Last())));
}

void Part2()
{
    List<string> input = File.ReadAllText("Input.txt").Split("\r\n").ToList();
    int separator = input.Where(x => x.StartsWith("m")).Select(x => input.IndexOf(x)).First();
    List<string> start = input.Take(separator).ToList().RemoveEmpty().SkipLast(1).ToList();
    start.Reverse();
    List<string> inMoves = input.Skip(separator - 1).ToList().RemoveEmpty();
    //----setup workplace---
    for (int i = 0; i < start.Count; i++)
    {
        start[i] = start[i].Replace("    ", "*").Replace(" ", "").Replace("[", "").Replace("]", "");
    }
    int stacks = start[0].Length;
    List<string> workplace = new();
    for (int i = 0; i < stacks; i++) workplace.Add(string.Empty);

    foreach (var line in start)
    {
        for (int i = 0; i < stacks; i++)
        {
            if (line[i] != '*') workplace[i] += line[i];
        }
    }
    //----end setup workplace----
    //----setup moves----
    List<(int, int, int)> moves = new();
    foreach (string s in inMoves)
    {
        string[] tmp = s.Split(" ");
        moves.Add((int.Parse(tmp[1]), int.Parse(tmp[3]), int.Parse(tmp[5])));
    }
    //----end setup moves----

    foreach ((int move, int from, int to) move in moves)
    {
        string tmp = workplace[move.from - 1].Substring(workplace[move.from - 1].Length - move.move);
        workplace[move.to - 1] += tmp;
        workplace[move.from - 1] = workplace[move.from - 1].Substring(0, workplace[move.from - 1].Length - move.move);

    }
    File.WriteAllText("Output2.txt", String.Join("", workplace.Select(x => x.Last())));
}

Part1();
Part2();

