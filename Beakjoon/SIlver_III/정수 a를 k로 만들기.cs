int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int k = input[1];
int[] distance = Enumerable.Repeat(-1, 1000001).ToArray();
Queue<int> q = new Queue<int>();
q.Enqueue(a);
distance[a] = 0;
while (q.Count > 0)
{
    int cur = q.Dequeue();
    if (cur == k)
        break;
    int next = cur + 1;
    if (next <= k && distance[next] == -1)
    {
        q.Enqueue(next);
        distance[next] = distance[cur] + 1;
    }
    next = cur * 2;
    if (next <= k && distance[next] == -1)
    {
        q.Enqueue(next);
        distance[next] = distance[cur] + 1;
    }
}
Console.WriteLine(distance[k]);