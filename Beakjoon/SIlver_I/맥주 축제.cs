int[] input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];
PriorityQueue<(int prefer, int content), int> abvQueue = new PriorityQueue<(int prefer, int abv), int>();
while (k-- > 0)
{
    input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
    int prefer = input[0];
    int content = input[1];
    abvQueue.Enqueue((prefer, content), content);
}
long preferSum = 0;
long contentMax = 0;
int count = 0;
PriorityQueue<(int prefer, int content), int> preQueue = new PriorityQueue<(int prefer, int abv), int>();
while (abvQueue.Count > 0)
{
    var cur = abvQueue.Dequeue();
    preferSum += cur.prefer;
    contentMax = Math.Max(contentMax, cur.content);
    count++;
    preQueue.Enqueue(cur, cur.prefer);
    if (count == n)
    {
        if (preferSum >= m)
        {
            Console.WriteLine(contentMax);
            return;
        }
        else
        {
            var v = preQueue.Dequeue();
            preferSum -= v.prefer;
            count--;
        }
    }
}
Console.WriteLine("-1");