using System.Text;

int n = int.Parse(Console.ReadLine());
int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] dp = new int[n];
int[] parent = new int[n];
for (int i = 0; i < n; i++)
{
    parent[i] = i;
}
for (int i = 0; i < n; i++)
{
    int length = 1;
    for (int j = i - 1; j >= 0; j--)
    {
        if (A[i] > A[j] && dp[j] + 1 > length)
        {
            parent[i] = j;
            length = dp[j] + 1;
        }
    }
    dp[i] = length;
}
int max = 0;
int node = 0;
for (int i = 0; i < n; i++)
{
    if (dp[i] > max)
    {
        max = dp[i];
        node = i;
    }
}
Stack<int> s = new Stack<int>();
s.Push(node);
while (node != parent[node])
{
    node = parent[node];
    s.Push(node);
}
StringBuilder sb = new StringBuilder();
sb.AppendLine(max.ToString());
while (s.Count > 0)
{
    sb.Append(A[s.Pop()] + " ");
}
Console.WriteLine(sb);