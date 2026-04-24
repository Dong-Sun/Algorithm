using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(int n, int[,] edge)
    {
        int answer = 0;
        List<int>[] vertex = new List<int>[n + 1];
        for (int i = 0; i < vertex.Length; i++)
            vertex[i] = new List<int>();

        for (int i = 0; i < edge.GetLength(0); i++)
        {
            int left = edge[i, 0];
            int right = edge[i, 1];
            vertex[left].Add(right);
            vertex[right].Add(left);
        }

        int[] distance = Enumerable.Repeat(-1, n + 1).ToArray();
        Queue<int> q = new Queue<int>();
        distance[1] = 0;
        q.Enqueue(1);
        int max = 0;
        while (q.Count > 0)
        {
            int cur = q.Dequeue();

            max = Math.Max(max, distance[cur]);

            foreach (var next in vertex[cur])
            {
                if (distance[next] == -1)
                {
                    distance[next] = distance[cur] + 1;
                    q.Enqueue(next);
                }
            }
        }

        for (int i = 1; i <= n; i++)
        {
            if (distance[i] == max)
                answer++;
        }
        return answer;
    }
}