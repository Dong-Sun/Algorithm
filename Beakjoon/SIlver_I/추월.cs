int n = int.Parse(Console.ReadLine());
Dictionary<string, int> dict = new Dictionary<string, int>();
string[] keys = new string[n];
for (int i = 0; i < n; i++)
{
    string key = Console.ReadLine();
    dict.Add(key, i);
    keys[i] = key;
}

int result = 0;
for (int i = 0; i < n; i++)
{
    string key = Console.ReadLine();
    if (dict[key] > i)
    {
        result++;
        foreach (var v in keys)
        {
            if (dict[v] >= i && dict[v] < dict[key])
                dict[v]++;
        }
        dict[key] = i;
    }
}
Console.WriteLine(result);