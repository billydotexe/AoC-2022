using System.Text;

void Part1()
{
    string input = File.ReadAllText("Input.txt");
    int TotalError = 0;
    foreach(var line in input.Split("\r\n"))
    {
        List<char> comp1 = line.Take(line.Length / 2).ToList();
        List<char> comp2 = line.Skip(line.Length / 2).ToList();

        char item = comp1.Join(comp2, x => x, y => y, (x, y) => x).First();

        int error = ((int)item - (int)'a' < 0 ? (int)item - (int)'A' + 26 : (int)item - (int) 'a') + 1;

        TotalError += error;
    }

    File.WriteAllText("Output1.txt", TotalError.ToString());
}

void Part2()
{
    string[] input = File.ReadAllText("Input.txt").Split("\r\n");
    int TotalValue = 0;

    for(int i = 0; i < input.Length; i += 3)
    {
        char[] bag1 = input[i].ToCharArray();
        char[] bag2 = input[i+1].ToCharArray();
        char[] bag3 = input[i+2].ToCharArray();

        char item = bag1.Join(bag2, x => x, y => y, (x, y) => x)
                        .Join(bag3, x => x, y => y, (x, y) => x)
                        .First();

        int value = ((int)item - (int)'a' < 0 ? (int)item - (int)'A' + 26 : (int)item - (int)'a') + 1;

        TotalValue += value;
    }

    File.WriteAllText("Output2.txt", TotalValue.ToString());
}

Part1();
Part2();