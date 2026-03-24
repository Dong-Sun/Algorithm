int t = int.Parse(Console.ReadLine());
int max = 1299709;
List<int> prime = new List<int>();
bool[] flag = new bool[max + 1];
for (int i = 2; i <= max; i++)
{
    if (flag[i]) continue;
    prime.Add(i);
    for (int j = i + i; j <= max; j += i)
    {
        flag[j] = true;
    }
}
while (t-- > 0)
{
    int k = int.Parse(Console.ReadLine());
    if (k == max)
    {
        Console.WriteLine("0");
        continue;
    }
    for (int i = 0; i < prime.Count; i++)
    {
        if (prime[i] == k)
        {
            Console.WriteLine("0");
            break;
        }
        else if (prime[i] < k && k < prime[i + 1])
        {
            Console.WriteLine($"{prime[i + 1] - prime[i]}");
            break;
        }
    }
}