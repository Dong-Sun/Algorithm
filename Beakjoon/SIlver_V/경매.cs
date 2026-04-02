int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int u = input[0];
int n = input[1];

int[] count = new int[u + 1];
List<(string, int)> list = new List<(string, int)>(n);
while (n-- > 0)
{
    string[] split = Console.ReadLine().Split();
    list.Add((split[0], int.Parse(split[1])));
}

foreach (var v in list)
{
    count[v.Item2]++;
}

int min = 100001;
for (int i = 1; i <= u; i++)
{
    if (count[i] != 0 && count[i] < min)
    {
        min = count[i];
    }
}

int find = -1;
for (int i = 1; i <= u; i++)
{
    if (count[i] == min)
    {
        find = i;
        break;
    }
}

foreach (var v in list)
{
    if (v.Item2 == find)
    {
        Console.WriteLine($"{v.Item1} {v.Item2}");
        break;
    }
}