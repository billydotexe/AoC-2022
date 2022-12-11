void Part1()
{
    string[] input = File.ReadAllLines("Input.txt");
    int visibleTrees = (input.Length * 2) + ((input[0].Length - 2) * 2);
    List<(int, int)> cardinals = new List<(int, int)>() { (0, 1), (1, 0), (0, -1), (-1, 0) };
    for (int i = 1; i < input.Length - 2; i++)
    {
        for(int j = 1; j < input[i].Length - 2; j++)
        {
            foreach((int x, int y) cardinal in cardinals) 
            {
                if (input[i + cardinal.x].ToCharArray()[j + cardinal.y] < input[i].ToCharArray()[j])
                {
                    visibleTrees++;
                    break;
                }
            }
        }
    }
    Console.WriteLine(visibleTrees);
}

void Part2()
{

}

Part1();
Part2();