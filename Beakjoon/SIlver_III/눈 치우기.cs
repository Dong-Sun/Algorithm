int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
PriorityQueue<int, int> pq = new();
foreach (var v in input)
{
    pq.Enqueue(v, -v);
}

int time = 0;
while (pq.Count > 0)
{
    time++;
    int t1 = pq.Dequeue() - 1;
    if (pq.Count > 0)
    {
        int t2 = pq.Dequeue() - 1;
        if (t2 > 0)
            pq.Enqueue(t2, -t2);
    }
    if (t1 > 0)
        pq.Enqueue(t1, -t1);
}
if (time > 1440)
    Console.WriteLine("-1");
else
    Console.WriteLine(time);