int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int n = input[2];
int m = input[3];

int[] bridge = Enumerable.Repeat(-1, 100001).ToArray();

Queue<int> q = new Queue<int>();
q.Enqueue(n);
while (q.Count > 0)
{
    int cur = q.Dequeue();
    if (cur == m)
    {
        Console.WriteLine(bridge[m] + 1);
        break;
    }

    if (cur - 1 >= 0 && bridge[cur - 1] == -1)
    {
        q.Enqueue(cur - 1);
        bridge[cur - 1] = bridge[cur] + 1;
    }
    if (cur - a >= 0 && bridge[cur - a] == -1)
    {
        q.Enqueue(cur - a);
        bridge[cur - a] = bridge[cur] + 1;
    }
    if (cur - b >= 0 && bridge[cur - b] == -1)
    {
        q.Enqueue(cur - b);
        bridge[cur - b] = bridge[cur] + 1;
    }
    if (cur + 1 <= 100000 && bridge[cur + 1] == -1)
    {
        q.Enqueue(cur + 1);
        bridge[cur + 1] = bridge[cur] + 1;
    }
    if (cur + a <= 100000 && bridge[cur + a] == -1)
    {
        q.Enqueue(cur + a);
        bridge[cur + a] = bridge[cur] + 1;
    }
    if (cur + b <= 100000 && bridge[cur + b] == -1)
    {
        q.Enqueue(cur + b);
        bridge[cur + b] = bridge[cur] + 1;
    }
    if (cur * a <= 100000 && bridge[cur * a] == -1)
    {
        q.Enqueue(cur * a);
        bridge[cur * a] = bridge[cur] + 1;
    }
    if (cur * b <= 100000 && bridge[cur * b] == -1)
    {
        q.Enqueue(cur * b);
        bridge[cur * b] = bridge[cur] + 1;
    }
}