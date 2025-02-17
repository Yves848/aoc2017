using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2017/07/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re1 = new(@"(\w+) \((\d+)\)");
Dictionary<string, int> weights = [];

Dictionary<string,Node> nodes = [];
string root = "";

file.ForEach(line =>
{
  var Parts = line.Split(" -> ");
  var m = re1.Match(Parts[0]);
  weights.Add(m.Groups[1].Value, int.Parse(m.Groups[2].Value));
});

file.ForEach(line =>
{
  var Parts = line.Split(" -> ");
  var m = re1.Match(Parts[0]);
  string name = m.Groups[1].Value;
  nodes.Add(name,new Node(name, int.Parse(m.Groups[2].Value)));
  // weights.Add(m.Groups[1].Value, int.Parse(m.Groups[2].Value));
  if (Parts.Count() > 1)
  {
    Parts[1].Split(',').ToList().ForEach(leaf =>
    {
      nodes[name].Childs.Add(new Node(leaf.Trim(), weights[leaf.Trim()]));
    });
  }
});

void part1()
{
  string ans = "";

  var temp = nodes.Where(n => n.Value.Childs.Count() > 0);
  temp.ToList().ForEach(node =>
  {
    string name = node.Value.Name;
    bool present = false;
    temp.ToList().ForEach(n =>
    {
      present = present || n.Value.Childs.Where(c => c.Name == name).Count() > 0;
    });
    if (!present) ans = name;
  });
  root = ans;
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

int branchWeight(Node branch,int weight){
  int i = 0;
  if (branch.Childs.Count == 0) {
    weight += weights[branch.Name];
  } else {
    while(i < branch.Childs.Count -1) {
      weight += branchWeight(nodes[branch.Childs[i].Name],weight);
      i++;
    }
  }
  
  return weight;
}

void printTree(Node branch, string parent) {
  int i = 0;
  Console.Write($"({parent})-{branch.Name}({branch.Weight})");
  if (nodes[branch.Name].Childs.Count > 0) Console.Write(" -> ");
  while (i < nodes[branch.Name].Childs.Count) {    
    printTree(nodes[branch.Childs[i].Name],nodes[branch.Name].Name);
    i++;
  }
  Console.WriteLine("...");
}

void part2()
{
  int ans = 0;
  List<int> w = [];
  
  var temp = nodes[root];
  printTree(temp,temp.Name);
  temp.Childs.ForEach(c => {
    Console.WriteLine(branchWeight(c,0));
  });

  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

public struct Node
{
  public string Name { get; set; }
  public int Weight { get; set; }
  public List<Node> Childs { get; set; }

  public Node(string name, int weight)
  {
    Name = name;
    Weight = weight;
    Childs = [];
  }

  public void AddNode(Node node)
  {
    Childs.Add(node);
  }
}