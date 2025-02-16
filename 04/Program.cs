using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2017/04/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";


void part1()
{
  int ans = 0;
  int i = 0;
  while(i < file.Count) {
    var mots = file[i].Split(" ").ToList();
    int j = 0;
    bool valide = true;
    while (j < mots.Count && valide) {
      valide = valide && mots.Where(m => m == mots[j]).Count() == 1;
      j++;
    }
    if (valide) ans++;
    i++;
  }
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  int i = 0;
  while(i < file.Count) {
    var mots = file[i].Split(" ").ToList();
    int j = 0;
    bool valide = true;
    while (j < mots.Count && valide) {
      List<char> mot = mots[j].ToCharArray().ToList();
      mot.Sort();
      string m1 = String.Join("",mot);
      int count = 0;
      mots.Where(m => m.Length == mot.Count).ToList().ForEach(cible => {
        List<char> mot2 = cible.ToCharArray().ToList();
        mot2.Sort();
        if (m1 == String.Join("",mot2)) count++;
      });
      valide = valide && count < 2;
      j++;
    }
    if (valide) ans++;
    i++;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
