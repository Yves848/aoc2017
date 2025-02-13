using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string file = args.Length > 0 ? File.ReadAllText(args[0]) : File.ReadAllText($"{home}/git/aoc2017/01/test.txt");
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";


void part1()
{
  int ans = 0;
  int i = 0;
  while (i < file.Length) {
    if (file[i] == (i < file.Length -2 ? file[i+1] : file[0])) ans += Convert.ToInt32(file[i].ToString());
    i++;
  }
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  int i = 0;
  int i2 = 0;
  int w = file.Length / 2;
  while (i < file.Length) {
    i2 = i + w;
    if (i2 > file.Length -1) i2 = (i+w)%file.Length;
    if (file[i] == file[i2]) ans += Convert.ToInt32(file[i].ToString());
    i++;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
