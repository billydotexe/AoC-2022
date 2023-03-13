using AdventUtility;

void Part1()
{
    //
    int startinTransmissionMarker = 4;
    string input = File.ReadAllText("Input.txt");
    int i = -1;
    string s = string.Empty;
    //we need to skip until we find a substring 
    //where every character is unique
    do
    {
        i++;
        s = input.Substring(i, startinTransmissionMarker);

    } 
    while (!s.IsEveryCharUnique());

    File.WriteAllText("Output1.txt", (i+ startinTransmissionMarker).ToString());
}

//this is the same as Part1 but with longer substrings
void Part2()
{
    int startinMessageMarker = 14;
    string input = File.ReadAllText("Input.txt");
    int i = -1;
    string s = string.Empty;
    do
    {
        i++;
        s = input.Substring(i, startinMessageMarker);

    } while (!s.IsEveryCharUnique());

    File.WriteAllText("Output2.txt", (i + startinMessageMarker).ToString());
}


Part1();
Part2();
