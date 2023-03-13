void Part1()
{
    string input = File.ReadAllText("Input.txt");
    int overlap = 0;

    foreach(var line in input.Split("\r\n"))
    {
        //divide the input
        var elves = line.Split(",");
        Elf elf1 = new(elves[0]);
        Elf elf2 = new(elves[1]);

        //check if the range of the 2 elves overlap somehow
        //one elf range needs to be completely inside the other one
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
        var elves = line.Split(",");
        Elf elf1 = new(elves[0]);
        Elf elf2 = new(elves[1]);

        //new logic for the overlap
        //the ranges can partially overlap
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