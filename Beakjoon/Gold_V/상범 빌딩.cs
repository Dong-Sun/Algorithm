while (true)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int L = input[0];
    int R = input[1];
    int C = input[2];

    if (L == 0 && R == 0 && C == 0)
        break;

    var building = new char[L, R, C];
    var visited = new bool[L, R, C];
    var distance = new int[L, R, C];
    var q = new Queue<(int l, int r, int c)>();

    for (int i = 0; i < L; i++)
    {
        for (int j = 0; j < R; j++)
        {
            string s = Console.ReadLine();
            for (int k = 0; k < C; k++)
            {
                building[i, j, k] = s[k];
                if (s[k].Equals('S'))
                {
                    q.Enqueue((i, j, k));
                    visited[i, j, k] = true;
                }
            }
        }
        Console.ReadLine();
    }

    int[] dl = { -1, 1, 0, 0, 0, 0 };
    int[] dr = { 0, 0, -1, 1, 0, 0 };
    int[] dc = { 0, 0, 0, 0, -1, 1 };
    int result = 0;
    while (q.Count > 0)
    {
        var cur = q.Dequeue();
        int l = cur.l;
        int r = cur.r;
        int c = cur.c;

        if (building[l, r, c].Equals('E'))
        {
            result = distance[l, r, c];
            break;
        }

        for (int i = 0; i < 6; i++)
        {
            int nl = l + dl[i];
            int nr = r + dr[i];
            int nc = c + dc[i];

            if (nl >= L || nl < 0) continue;
            if (nr >= R || nr < 0) continue;
            if (nc >= C || nc < 0) continue;
            if (visited[nl, nr, nc]) continue;
            if (building[nl, nr, nc].Equals('#')) continue;

            q.Enqueue((nl, nr, nc));
            visited[nl, nr, nc] = true;
            distance[nl, nr, nc] = distance[l, r, c] + 1;
        }
    }

    if (result == 0)
        Console.WriteLine("Trapped!");
    else
        Console.WriteLine("Escaped in {0} minute(s).", result);
}