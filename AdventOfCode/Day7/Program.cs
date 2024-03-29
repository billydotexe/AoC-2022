﻿using System.Linq.Expressions;

void Part1()
{
    string input = File.ReadAllText("Input.txt");
    AdventDirectory root = new("/");
    List<AdventDirectory> directories = new() { root };
    string currentDirectory = root.Id;
    Command? cmd = null;
    foreach (var line in input.Split("\r\n"))
    {
        //either a command and its args or a line of output
        string[] std = line.Split(" ");
        //cd command
        if (std[0] == "$")
        {
            //skip the $ and get the command + args
            cmd = new(std.Skip(1).ToArray());
            if (cmd.Text == "cd" && cmd.Arguments is not null)
            {
                //back to the root
                if (cmd.Arguments == "/")
                {
                    currentDirectory = root.Id;
                }
                //go one level back in the hierarchy
                else if (cmd.Arguments == "..")
                {
                    currentDirectory = directories.Where(x => x.Id == currentDirectory).Select(x => x.ParentId).First() ?? root.Id;
                }
                //go inside the directory specified as parameter
                else
                {
                    //obs: there might be more directories with the same name in different paths
                    //the where statement cover that case letting us work only in the right directory
                    List<AdventDirectory> curr = directories.Where(x => x.Id == currentDirectory).Select(x => x.Directories).First();
                    currentDirectory = curr.Where(x => x.Name == cmd.Arguments).Select(x => x.Id).First();
                }
            }
        }
        //either ls command or result
        else if(cmd is not null && cmd.Text == "ls")
        {
            //dir
            if (std[0] == "dir")
            {
                AdventDirectory newDir = new(std[1], currentDirectory);
                directories.Where(x => x.Id == currentDirectory).First().Directories.Add(newDir);
                directories.Add(newDir);
            }
            //file
            else
            {
                AdventFile f = new(std[1], long.Parse(std[0]));
                directories.Where(x => x.Id == currentDirectory).First().Files.Add(f);
            }
        }
    }
    //get
    long totalSize = directories.Select(x => x.Size).Where(x => x < 100000).Sum();

    File.WriteAllText("Output1.txt", totalSize.ToString());
}

//same logics as Part1 until the end
void Part2()
{
    string input = File.ReadAllText("Input.txt");
    AdventDirectory root = new("/");
    List<AdventDirectory> directories = new() { root };
    string currentDirectory = root.Id;
    Command? cmd = null;
    foreach (var line in input.Split("\r\n"))
    {
        string[] std = line.Split(" ");
        if (std[0] == "$")
        {
            cmd = new(std.Skip(1).ToArray());
            if (cmd.Text == "cd" && cmd.Arguments is not null)
            {
                if (cmd.Arguments == "/")
                {
                    currentDirectory = root.Id;
                }
                else if (cmd.Arguments == "..")
                {
                    currentDirectory = directories.Where(x => x.Id == currentDirectory).Select(x => x.ParentId).First() ?? root.Id;
                }
                else
                {
                    List<AdventDirectory> curr = directories.Where(x => x.Id == currentDirectory).Select(x => x.Directories).First();
                    currentDirectory = curr.Where(x => x.Name == cmd.Arguments).Select(x => x.Id).First();
                }
            }
        }
        else if (cmd is not null && cmd.Text == "ls")
        {
            if (std[0] == "dir")
            {
                AdventDirectory newDir = new(std[1], currentDirectory);
                directories.Where(x => x.Id == currentDirectory).First().Directories.Add(newDir);
                directories.Add(newDir);
            }
            else
            {
                AdventFile f = new(std[1], long.Parse(std[0]));
                directories.Where(x => x.Id == currentDirectory).First().Files.Add(f);
            }
        }
    }
    long requiredSpace = 30000000 - (70000000 - root.Size);
    //we need the directory with lower size above the required
    File.WriteAllText("Output2.txt", directories.Where(x => x.Size > requiredSpace).Select(x => x.Size).Min().ToString());
}

Part1();
Part2();

class Command
{
    public string Text { get; set; }
    public string? Arguments { get; set; }
    public Command(string[] input)
    {
        Text = input[0];
        if (input.Length > 1)
            Arguments = input[1];
    }
}

class AdventDirectory
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string? ParentId { get; set; }
    public string Name { get; set; }
    public List<AdventFile> Files { get; set; }
    public List<AdventDirectory> Directories { get; set; }

    //recursive size
    //get the size of every subdirectory until we reach all ends
    public long Size { get => Files.Select(x => x.Size).Sum() + Directories.Select(x => x.Size).Sum(); }

    public AdventDirectory(string input, string? parent = null)
    {
        Name = input;
        ParentId = parent;
        Files = new List<AdventFile>();
        Directories = new List<AdventDirectory>();
    }
}

class AdventFile
{
    public long Size { get; set; }
    public string Name { get; set; }

    public AdventFile(string name, long size)
    {
        Name = name;
        Size = size;
    }
}