int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
int start = int.Parse(Console.ReadLine()) - 1;
bool[] visited = new bool[n];
Queue<int> q = new Queue<int>();
q.Enqueue(start);
visited[start] = true;
while (q.Count > 0)
{
    int cur = q.Dequeue();
    visited[cur] = true;
    if (cur + arr[cur] < n && !visited[cur + arr[cur]])
        q.Enqueue(cur + arr[cur]);
    if (cur - arr[cur] >= 0 && !visited[cur - arr[cur]])
        q.Enqueue(cur - arr[cur]);
}
int result = 0;
for (int i = 0; i < n; i++)
    if (visited[i]) result++;
Console.WriteLine(result);