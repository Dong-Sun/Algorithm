using System;
using System.Collections.Generic;

public class Solution
{
    List<int> list = new List<int>();
    Dictionary<string, int> dict = new Dictionary<string, int>();
    int result = 0;
    public int solution(string[,] clothes)
    {
        int answer = 0;

        for (int i = 0; i < clothes.GetLength(0); i++)
        {
            string type = clothes[i, 1];
            if (dict.ContainsKey(type))
                list[dict[type]]++;
            else
            {
                dict.Add(type, 0);
                list.Add(1);
                dict[type] = list.Count - 1;
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list[i]; j++)
            {
                Dfs(i + 1, 1);
            }
        }
        answer = result;
        return answer;
    }

    void Dfs(int type, int sum)
    {
        if (type == list.Count)
        {
            result += sum;
            return;
        }

        Dfs(type + 1, sum * (list[type] + 1));
    }
}