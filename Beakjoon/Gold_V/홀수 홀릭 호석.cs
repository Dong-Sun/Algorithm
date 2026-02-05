// Initialize
int n = int.Parse(Console.ReadLine());
int max = 0;
int min = int.MaxValue;

// Solution
Dfs(n, 0);

// Output
Console.WriteLine($"{min} {max}");

// Function
void Dfs(int n, int count)
{
    count = count + Counting(n);
    if (n < 10)
    {
        min = Math.Min(min, count);
        max = Math.Max(max, count);
        return;
    }
    else if (n < 100)
    {
        Dfs(n / 10 + n % 10, count);
        return;
    }
    string s = n.ToString();
    for (int i = 1; i < s.Length; i++)
    {
        for (int j = i + 1; j < s.Length; j++)
        {
            Dfs(int.Parse(s[..i]) + int.Parse(s[i..j]) + int.Parse(s[j..]), count);
        }
    }
}
int Counting(int n)
{
    int result = 0;
    while (n > 0)
    {
        if (n % 2 == 1)
            result++;
        n = n / 10;
    }
    return result;
}