using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string file = args.Length > 0 ? File.ReadAllText(args[0]) : File.ReadAllText($"{home}/git/aoc2017/06/test.txt");
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";


void part1()
{
  List<int> blocks = file.Split(" ").Select(i => int.Parse(i)).ToList();
  List<List<int>> seen = [];
  int ans = 0;
  bool p2 = false;
  while (true)
  {
    int max = blocks.Max();
    int index = blocks.IndexOf(max);
    int i = index + 1;
    blocks[index] = 0;
    while (max > 0)
    {
      if (i > blocks.Count - 1) i = 0;
      // if (i != index) {
      blocks[i] = blocks[i] + 1;
      // }
      i++;
      max--;
    }
    ans++;
    bool ok = false;
    seen.ForEach(l =>
    {
      ok = ok || l.SequenceEqual(blocks);
    });
    if (ok)
    {
      if (p2)
      {
        Console.WriteLine($"Part 2 - Answer : {ans}");
        break;
      }
      else
      {
        Console.WriteLine($"Part 1 - Answer : {ans}");
        ans = 0;
        seen.Clear();
        p2 = true;
      }
    }
    seen.Add([.. blocks]);

  }
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

// part2();
