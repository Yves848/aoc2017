using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
int puzzle = 277678;
if (args.Length > 0)
{
  puzzle = int.Parse(args[0]);
}
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

(int x, int y)[] dirs = {
  (1,0),   // right
  (0,-1),  // up
  (-1,0),  // left
  (0,1)   // down
};

Dictionary<(int x, int y), int> spiral = [];

(int x, int y) center = (Console.BufferWidth / 2, Console.BufferHeight / 2);
void part1()
{
  int ans = 0;
  int i = 0;
  int d = 0;
  int inc = 1;
  // spiral.Add((0, 0), 1);
  (int x, int y) = (0, 0);
  while (i < puzzle - 1)
  {

    for (int step = 0; step < 2; step++)
    {
      (int dx, int dy) = dirs[d];
      for (int j = 0; j < inc; j++)
      {
        if (i < puzzle)
        {
          spiral.Add((x, y), i + 1);
          // Console.CursorLeft = center.x + x;
          // Console.CursorTop = center.y + y;
          // Console.Write(i + 1);
          x += dx;
          y += dy;
        }
        i++;
      }
      d++;
      if (d > dirs.Count() - 1)
      {
        d = 0;
      }
    }
    inc++;
  }
  Console.CursorTop = Console.BufferHeight - 2;
  Console.WriteLine(spiral.Last().Key);
  ans = Math.Abs(0 - spiral.Last().Key.x) + Math.Abs(0 - spiral.Last().Key.y);
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

int sum((int x, int y) cell) {
  int result = 1;

  return result;
}

void part2()
{
  int ans = 0;
  int i = 0;
  int d = 0;
  int inc = 1;
  spiral.Add((0, 0), 1);
  (int x, int y) = (0, 0);
  while (i < puzzle - 1)
  {
    for (int step = 0; step < 2; step++)
    {
      (int dx, int dy) = dirs[d];
      for (int j = 0; j < inc; j++)
      {
        if (i < puzzle)
        {
          spiral.Add((x, y), i + 1);
          x += dx;
          y += dy;
        }
        i++;
      }
      d++;
      if (d > dirs.Count() - 1)
      {
        d = 0;
      }
    }
    inc++;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
