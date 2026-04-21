using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        Queue<(int weight, int time)> q = new Queue<(int weight, int time)>();
        int next = 0; int w = 0; int time = 0;
        while (next < truck_weights.Length || q.Count > 0)
        {
            if (q.Count > 0 && time - q.Peek().time >= bridge_length)
            {
                var v = q.Dequeue();
                w -= v.weight;
            }
            if (next < truck_weights.Length && w + truck_weights[next] <= weight)
            {
                q.Enqueue((truck_weights[next], time));
                w += truck_weights[next];
                next++;
            }
            time++;
        }
        return time;
    }
}