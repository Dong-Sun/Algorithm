int n = int.Parse(Console.ReadLine());
HashSet<string> hs = new HashSet<string>();
string[] arr = new string[n];
int pivot = -1;
for (int i = 0; i < n; i++)
{
    string s = Console.ReadLine();
    arr[i] = s;
    hs.Add(s);
    if (s == "?")
        pivot = i;
}
int m = int.Parse(Console.ReadLine());
if (n == 1)
{
    Console.WriteLine(Console.ReadLine());
    return;
}
for (int i = 0; i < m; i++)
{
    string s = Console.ReadLine();
    if (hs.Contains(s))
        continue;

    if (pivot == 0)
    {
        if (s[^1] != arr[pivot + 1][0])
            continue;
    }
    else if (pivot == n - 1)
    {
        if (s[0] != arr[pivot - 1][^1])
            continue;
    }
    else if (s[0] != arr[pivot - 1][^1] || s[^1] != arr[pivot + 1][0])
        continue;
    Console.WriteLine(s);
    return;
}