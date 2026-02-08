using System.Text;

// Initialize
StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
while (n-- > 0)
{
    long[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), long.Parse);

    // Solution
    long T = input[0];
    string result = "SYJKGW";
    Dictionary<long, int> dict = new();
    for (int i = 1; i <= T; i++)
    {
        long cur = input[i];
        dict.TryAdd(cur, 0);
        dict[cur]++;
        if (dict[cur] > T / 2)
        {
            result = cur.ToString();
            break;
        }
    }
    sb.AppendLine(result);
}

// Output
Console.Write(sb);