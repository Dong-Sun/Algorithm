int n = int.Parse(Console.ReadLine());
int max = 0;
int[,] table = new int[n, n];
for (int i = 0; i < n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        table[i, j] = input[j];
        max = Math.Max(max, input[j]);
    }
}

int[] dy = { 1, -1, 0, 0 };
int[] dx = { 0, 0, 1, -1 };
int result = 0;
for (int pivot = 0; pivot <= max; pivot++)
{
    int count = 0;
    bool[,] visited = new bool[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (visited[i, j] || table[i, j] <= pivot)
                continue;

            Queue<(int y, int x)> q = new Queue<(int y, int x)>();
            q.Enqueue((i, j));
            visited[i, j] = true;
            count++;
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                int cy = cur.y;
                int cx = cur.x;
                for (int k = 0; k < 4; k++)
                {
                    int ny = cy + dy[k];
                    int nx = cx + dx[k];
                    if (ny < 0 || ny >= n || nx < 0 || nx >= n)
                        continue;
                    if (visited[ny, nx] || table[ny, nx] <= pivot)
                        continue;
                    q.Enqueue((ny, nx));
                    visited[ny, nx] = true;
                }
            }
        }
    }
    result = Math.Max(result, count);
}
Console.WriteLine(result);