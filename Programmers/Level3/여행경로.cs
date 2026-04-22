using System;
using System.Collections.Generic;

public class Solution
{
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    Dictionary<string, List<bool>> visited = new Dictionary<string, List<bool>>();
    string[] answer;
    bool end = false;
    Stack<string> s = new Stack<string>();
    public string[] solution(string[,] tickets)
    {
        for (int i = 0; i < tickets.GetLength(0); i++)
        {
            string cur = tickets[i, 0];
            string next = tickets[i, 1];
            if (!dict.ContainsKey(cur))
            {
                dict.Add(cur, new List<string>());
                visited.Add(cur, new List<bool>());
            }
            dict[cur].Add(next);
            visited[cur].Add(false);
        }

        foreach (var v in dict)
            v.Value.Sort();

        answer = new string[tickets.GetLength(0) + 1];
        Dfs("ICN", tickets.GetLength(0) + 1);
        return answer;
    }
    void Dfs(string key, int max)
    {
        s.Push(key);
        if (s.Count == max)
        {
            int index = s.Count - 1;
            while (s.Count > 0)
                answer[index--] = s.Pop();
            end = true;
            return;
        }

        if (!dict.ContainsKey(key))
        {
            s.Pop();
            return;
        }
        for (int i = 0; i < dict[key].Count; i++)
        {
            if (end)
                return;
            if (visited[key][i])
                continue;
            visited[key][i] = true;
            Dfs(dict[key][i], max);
            visited[key][i] = false;
        }
        if (end)
            return;
        s.Pop();
    }
}