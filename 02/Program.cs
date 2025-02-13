using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2017/02/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";



void part1()
{
  int ans = 0;
  file.ForEach(line =>
  {
    List<int> row = [];
    line.Split("\t", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(num =>
    {
      row.Add(int.Parse(num));
    });
    ans += row.Max() - row.Min();
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  file.ForEach(line =>
  {
    List<int> row = [];
    line.Split("\t", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(num =>
    {
      row.Add(int.Parse(num));
    });

    int i = 0;
    row.Sort((a, b) => b.CompareTo(a));
    while (i < row.Count)
    {
      int j = row.Count - 1;
      while (row[i] > row[j] && j > 0)
      {
        if (row[i] % row[j] == 0)
        {
          ans += row[i] / row[j];
          i = row.Count;
          break;
        }
        j--;
      }
      i++;
    }
  });
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
