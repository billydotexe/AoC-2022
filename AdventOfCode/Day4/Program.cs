void Part1()
{
    string input = File.ReadAllText("Input.txt");
    int overlap = 0;

    foreach(var line in input.Split("\r\n"))
    {
        Elf elf1 = new(line.Split(",")[0]);
        Elf elf2 = new(line.Split(",")[1]);

        if((elf1.start >= elf2.start && elf1.stop <= elf2.stop) 
            || (elf2.start >= elf1.start && elf2.stop <= elf1.stop))
        {
            overlap++;
        }
    }

    File.WriteAllText("Output1.txt", overlap.ToString());
}

void Part2()
{
    string input = File.ReadAllText("Input.txt");
    int overlap = 0;

    foreach(var line in input.Split("\r\n"))
    {
        Elf elf1 = new(line.Split(",")[0]);
        Elf elf2 = new(line.Split(",")[1]);

        if(
            (elf1.start >= elf2.start && elf1.start <= elf2.stop)
            || (elf1.stop >= elf2.start && elf1.stop <= elf2.stop)
            || (elf2.start >= elf1.start && elf2.start <= elf1.stop)
            || (elf2.stop >= elf1.start && elf2.stop <= elf1.stop)
            )
        {
            overlap++;
        }
    }

    File.WriteAllText("Output2.txt", overlap.ToString());
}

Part1();
Part2();

public class Elf
{
    public int start { get; set; }
    public int stop { get; set; }
    public Elf(string startAndStop)
    {
        string[] tmp = startAndStop.Split("-");
        start = int.Parse(tmp[0]);
        stop = int.Parse(tmp[1]);
    }
}