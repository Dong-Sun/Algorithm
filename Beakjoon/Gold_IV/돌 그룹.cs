int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int sum = input[0] + input[1] + input[2];
if (sum % 3 != 0)
{
    Console.WriteLine("0");
    return;
}
Queue<(int n1, int n2)> q = new();
q.Enqueue((input[0], input[1]));
bool[,] visited = new bool[2001, 2001];
visited[input[0], input[1]] = true;
while (q.Count > 0)
{
    var cur = q.Dequeue();
    int[] num = new int[3];
    num[0] = cur.n1;
    num[1] = cur.n2;
    num[2] = sum - num[0] - num[1];
    if (num[0] == num[1] && num[0] == num[2])
    {
        Console.WriteLine("1");
        return;
    }
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (i == j) continue;
            if (num[i] != num[j])
            {
                int x = num[i] < num[j] ? num[i] : num[j];
                int y = num[i] < num[j] ? num[j] : num[j];
                if (!visited[x + x, y - x])
                {
                    q.Enqueue((x + x, y - x));
                    visited[x + x, y - x] = true;
                }
                if (!visited[y - x, x + x])
                {
                    q.Enqueue((y - x, x + x));
                    visited[y - x, x + x] = true;
                }
            }
        }
    }
}
Console.WriteLine("0");