using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY)
    {
        int answer = 0;

        bool[,] table = new bool[101, 101];
        for (int i = 0; i < rectangle.GetLength(0); i++)
        {
            int x1 = rectangle[i, 0] * 2;
            int y1 = rectangle[i, 1] * 2;
            int x2 = rectangle[i, 2] * 2;
            int y2 = rectangle[i, 3] * 2;
            for (int x = x1; x <= x2; x++)
            {
                table[y1, x] = true;
                table[y2, x] = true;
            }
            for (int y = y1; y <= y2; y++)
            {
                table[y, x1] = true;
                table[y, x2] = true;
            }
        }

        for (int i = 0; i < rectangle.GetLength(0); i++)
        {
            int x1 = rectangle[i, 0] * 2;
            int y1 = rectangle[i, 1] * 2;
            int x2 = rectangle[i, 2] * 2;
            int y2 = rectangle[i, 3] * 2;
            for (int y = y1 + 1; y < y2; y++)
            {
                for (int x = x1 + 1; x < x2; x++)
                {
                    table[y, x] = false;
                }
            }
        }

        Queue<(int y, int x)> q = new Queue<(int y, int x)>();
        q.Enqueue((characterY * 2, characterX * 2));
        int[,] distance = new int[101, 101];
        bool[,] visited = new bool[101, 101];
        visited[characterY * 2, characterX * 2] = true;

        int[] dy = { 1, -1, 0, 0 };
        int[] dx = { 0, 0, 1, -1 };
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            int cy = cur.y;
            int cx = cur.x;
            if (cy == itemY * 2 && cx == itemX * 2)
            {
                answer = distance[cy, cx] / 2;
                break;
            }

            for (int i = 0; i < 4; i++)
            {
                int ny = cy + dy[i];
                int nx = cx + dx[i];

                if (ny < 1 || ny > 100 || nx < 1 || nx > 100)
                    continue;
                if (table[ny, nx] == true && visited[ny, nx] == false)
                {
                    q.Enqueue((ny, nx));
                    visited[ny, nx] = true;
                    distance[ny, nx] = distance[cy, cx] + 1;
                }
            }
        }

        return answer;
    }
}