using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
while (t-- > 0)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int n = input[0];
    int m = input[1];
    List<int>[] edges = new List<int>[n + 1];
    for (int i = 0; i <= n; i++)
        edges[i] = new List<int>();

    for (int i = 0; i < m; i++)
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    sb.AppendLine((n - 1).ToString());
}
Console.WriteLine(sb);