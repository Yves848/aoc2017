using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2017/05/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
List<int> stack = file.Select(i => int.Parse(i)).ToList();

void part1()
{
  int ans = 0;
  int i = 0;
  while (i >= 0 && i < stack.Count) {
    var next = i + stack[i];
    stack[i] = stack[i] +1;
    i = next;
    ans++;
  }
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  stack = file.Select(i => int.Parse(i)).ToList();
  int ans = 0;
  int i = 0;
  while (i >= 0 && i < stack.Count) {
    var next = i + stack[i];
    stack[i] = stack[i] >= 3 ? stack[i] -1 : stack[i] +1;
    i = next;
    ans++;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
