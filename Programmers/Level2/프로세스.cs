using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int solution(int[] priorities, int location)
    {
        int answer = 0;
        Queue<(int index, int priority)> q = new Queue<(int index, int priority)>();
        for (int i = 0; i < priorities.Length; i++)
            q.Enqueue((i, priorities[i]));

        int result = 1;
        while (q.Count > 0)
        {
            int max = q.Max(x => x.priority);
            var cur = q.Dequeue();
            if (cur.priority == max)
            {
                if (cur.index == location)
                {
                    answer = result;
                    break;
                }
                else
                    result++;
            }
            else
                q.Enqueue(cur);
        }
        return answer;
    }
}