using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int r = input[2];

int count = 1;
var visited = new int[n + 1];
var edges = new List<int>[n + 1];
for (int i = 0; i <= n; i++)
    edges[i] = new List<int>();

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int left = input[0];
    int right = input[1];
    edges[left].Add(right);
    edges[right].Add(left);
}

for (int i = 1; i <= n; i++)
    edges[i].Sort();

Dfs(r);

for (int i = 1; i <= n; i++)
    sb.AppendLine(visited[i].ToString());

Console.WriteLine(sb);

void Dfs(int node)
{
    visited[node] = count++;
    foreach (var next in edges[node])
    {
        if (visited[next] == 0)
            Dfs(next);
    }
}