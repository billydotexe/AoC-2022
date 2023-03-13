using System.Text;

void Part1()
{
    string input = File.ReadAllText("Input.txt");
    int TotalError = 0;
    foreach(var line in input.Split("\r\n"))
    {
        List<char> comp1 = line.Take(line.Length / 2).ToList();
        List<char> comp2 = line.Skip(line.Length / 2).ToList();

        //join the 2 lists to get the first common character
        //there should be one in every line in the input so 
        //there's no need to handle border cases
        char item = comp1.Join(comp2, x => x, y => y, (x, y) => x).First();

        //some cast char to int magic to calculate the error
        int error = (int)char.ToLower(item) - (int)'a' + 1;

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
        //compare every 3 lines
        char[] bag1 = input[i].ToCharArray();
        char[] bag2 = input[i+1].ToCharArray();
        char[] bag3 = input[i+2].ToCharArray();

        //join the 3 lists to get the first common character
        //there should be one in every group in the input so 
        //there's no need to handle border cases
        char item = bag1.Join(bag2, x => x, y => y, (x, y) => x)
                        .Join(bag3, x => x, y => y, (x, y) => x)
                        .First();

        //some cast char to int magic to calculate the error
        int value = (int)char.ToLower(item) - (int)'a' + 1;

        TotalValue += value;
    }

    File.WriteAllText("Output2.txt", TotalValue.ToString());
}

Part1();
Part2();


class User
{
    public string Name { get; set; }
    public int age { get; set; }
}