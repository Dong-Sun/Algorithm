// 입력
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[,] map = new int[n + 2, m + 2];
for (int i = 1; i <= n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j <= m; j++)
        map[i, j] = input[j - 1];
}
// 구현
int[] dy = { -1, 1, 0, 0 };
int[] dx = { 0, 0, -1, 1 };
bool[,] visited = new bool[n + 2, m + 2];
int order = 1;
Queue<(int y, int x)> q = new();
for (int y = 1; y <= n; y++)
{
    for (int x = 1; x <= m; x++)
    {
        if (map[y, x] == 0 || visited[y, x] == true)
            continue;

        q.Enqueue((y, x));
        visited[y, x] = true;
        while (q.Count > 0)
        {
            var item = q.Dequeue();
            int cy = item.y;
            int cx = item.x;
            map[cy, cx] = order;
            for (int d = 0; d < 4; d++)
            {
                int ny = cy + dy[d];
                int nx = cx + dx[d];
                if (ny > n || ny < 1 || nx > m || nx < 1)
                    continue;
                if (visited[ny, nx] == true || map[ny, nx] == 0)
                    continue;
                q.Enqueue((ny, nx));
                visited[ny, nx] = true;
            }
        }
        order++;
    }
}

// 가능한 모든 다리(간선)
List<int>[] edges = new List<int>[order];
for (int i = 0; i < order; i++)
    edges[i] = new List<int>();

int[,] distance = new int[order, order];
for (int y = 1; y <= n; y++)
{
    for (int x = 1; x <= m; x++)
    {
        if (map[y, x] != 0)
        {
            // 다리 놓기
            int index = map[y, x];
            int dist = 1;
            while (y + dist <= n && map[y + dist, x] == 0) dist++;
            if (y <= n && map[y + dist, x] != 0 && map[y + dist, x] != index)
            {
                if (dist - 1 >= 2)
                {
                    if (distance[index, map[y + dist, x]] == 0)
                    {
                        edges[index].Add(map[y + dist, x]);
                        distance[index, map[y + dist, x]] = dist - 1;
                    }
                    else if (dist - 1 < distance[index, map[y + dist, x]])
                        distance[index, map[y + dist, x]] = dist - 1;
                }

            }
            dist = 1;
            while (y - dist >= 1 && map[y - dist, x] == 0) dist++;
            if (y >= 1 && map[y - dist, x] != 0 && map[y - dist, x] != index)
            {
                if (dist - 1 >= 2)
                {
                    if (distance[index, map[y - dist, x]] == 0)
                    {
                        edges[index].Add(map[y - dist, x]);
                        distance[index, map[y - dist, x]] = dist - 1;
                    }
                    else if (dist - 1 < distance[index, map[y - dist, x]])
                        distance[index, map[y - dist, x]] = dist - 1;
                }
            }
            dist = 1;
            while (x + dist <= m && map[y, x + dist] == 0) dist++;
            if (x <= m && map[y, x + dist] != 0 && map[y, x + dist] != index)
            {
                if (dist - 1 >= 2)
                {
                    if (distance[index, map[y, x + dist]] == 0)
                    {
                        edges[index].Add(map[y, x + dist]);
                        distance[index, map[y, x + dist]] = dist - 1;
                    }
                    else if (dist - 1 < distance[index, map[y, x + dist]])
                        distance[index, map[y, x + dist]] = dist - 1;
                }
            }
            dist = 1;
            while (x - dist >= 1 && map[y, x - dist] == 0) dist++;
            if (x >= 1 && map[y, x - dist] != 0 && map[y, x - dist] != index)
            {
                if (dist - 1 >= 2)
                {
                    if (distance[index, map[y, x - dist]] == 0)
                    {
                        edges[index].Add(map[y, x - dist]);
                        distance[index, map[y, x - dist]] = dist - 1;
                    }
                    else if (dist - 1 < distance[index, map[y, x - dist]])
                        distance[index, map[y, x - dist]] = dist - 1;
                }
            }
        }
    }
}
// 모든 조합 찾기
int result = -1;
bool[] able = new bool[order];

for (int start = 1; start < order; start++)
{
    able[start] = true;
    foreach (var next in edges[start])
    {
        able[next] = true;
        Dfs(next, distance[start, next], 2);
        able[next] = false;
    }
    able[start] = false;
}

void Dfs(int node, int dist, int depth)
{
    if (depth == order - 1)
    {
        if (result == -1 || result > dist)
            result = dist;
        return;
    }

    for (int k = 1; k < order; k++)
    {
        int next = k;
        if (able[next] == false)
        {
            int min = int.MaxValue;
            // 이미 방문한 섬에서 다리를 놓는게 더 짧은 경우
            for (int i = 1; i < able.Length; i++)
                if (able[i] == true && distance[i, next] >= 2)
                    min = Math.Min(min, distance[i, next]);
            if (min == int.MaxValue)
                continue;
            able[next] = true;
            Dfs(next, dist + min, depth + 1);
            able[next] = false;
        }
    }
}

// 출력
Console.WriteLine(result);