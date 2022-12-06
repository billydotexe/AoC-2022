void Part1()
{
    string input = File.ReadAllText("Input1.txt");
    int? maxCalories = null;
    int calories = 0;

    foreach(var line in input.Split("\r\n"))
    {
        if(line == "")
        {
            if (maxCalories is null || calories > maxCalories) maxCalories = calories;
            calories = 0;
        }
        else
        {
            calories += int.Parse(line);
        }
    }
    File.WriteAllText("Output1.txt", maxCalories.ToString());
}


void Part2()
{
    string input = File.ReadAllText("Input1.txt");

    List<int> maxCalories = new();
    int calories = 0;

    foreach (var line in input.Split("\r\n"))
    {
        if (line == "")
        {
            if (maxCalories.Count < 3) maxCalories.Add(calories);
            else
            {
                List<int> list = new List<int>();
                list.Add(calories);
                list.AddRange(maxCalories);
                maxCalories = list.OrderBy(x => x).Skip(1).Take(3).ToList();
            }
            calories = 0;
        }
        else
        {
            calories += int.Parse(line);
        }
    }
    File.WriteAllText("Output2.txt", maxCalories.Sum().ToString());
}

Part1();
Part2();