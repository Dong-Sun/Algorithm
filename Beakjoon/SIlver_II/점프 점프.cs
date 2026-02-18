// input
int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

// solution
int[] distance = Enumerable.Repeat(int.MaxValue, n).ToArray();
distance[0] = 0;
Queue<int> q = new Queue<int>();
q.Enqueue(0);
while (q.Count > 0)
{
    int cur = q.Dequeue();
    if (cur == n - 1)
    {
        Console.WriteLine(distance[cur]);
        return;
    }

    for (int i = 1; i <= input[cur]; i++)
    {
        int next = cur + i;
        if (next >= n)
            continue;
        if (distance[cur] + 1 < distance[next])
        {
            q.Enqueue(next);
            distance[next] = distance[cur] + 1;
        }
    }
}

// print
System.Console.WriteLine("-1");