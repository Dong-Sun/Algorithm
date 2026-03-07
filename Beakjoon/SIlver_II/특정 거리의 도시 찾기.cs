using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];
int x = input[3];
List<int>[] edeges = new List<int>[n + 1];
for (int i = 0; i <= n; i++)
    edeges[i] = new List<int>();
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int start = input[0];
    int end = input[1];
    edeges[start].Add(end);
}
int[] distance = Enumerable.Repeat(-1, n + 1).ToArray();
Queue<int> q = new Queue<int>();
q.Enqueue(x);
distance[x] = 0;
while (q.Count > 0)
{
    int cur = q.Dequeue();
    foreach (int next in edeges[cur])
    {
        if (distance[next] != -1)
            continue;
        q.Enqueue(next);
        distance[next] = distance[cur] + 1;
    }
}
StringBuilder sb = new StringBuilder();
for (int i = 1; i <= n; i++)
{
    if (i == x)
        continue;
    if (distance[i] == k)
        sb.AppendLine(i.ToString());
}
if (sb.Length == 0)
    Console.WriteLine("-1");
else
    Console.Write(sb);