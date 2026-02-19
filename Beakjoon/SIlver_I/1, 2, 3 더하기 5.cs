using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int mod = 1000000009;
long[,] dp = new long[100001, 4];
dp[1, 1] = 1;
dp[2, 2] = 1;
dp[3, 1] = 1;
dp[3, 2] = 1;
dp[3, 3] = 1;
for (int i = 4; i <= 100000; i++)
{
    dp[i, 1] = (dp[i - 1, 2] + dp[i - 1, 3]) % mod;
    dp[i, 2] = (dp[i - 2, 1] + dp[i - 2, 3]) % mod;
    dp[i, 3] = (dp[i - 3, 1] + dp[i - 3, 2]) % mod;
}
while (t-- > 0)
{
    int n = int.Parse(Console.ReadLine());
    long result = 0;
    for (int i = 1; i <= 3; i++)
        result += dp[n, i];
    result %= mod;
    sb.AppendLine(result.ToString());
}
Console.WriteLine(sb);