int n = int.Parse(Console.ReadLine());
int mod = 9901;
int[,] dp = new int[n, 3];
dp[0, 0] = 1;
dp[0, 1] = 1;
dp[0, 2] = 1;
for (int i = 1; i < n; i++)
{
    dp[i, 0] = (dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) % mod;
    dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2]) % mod;
    dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 1]) % mod;
}
int result = 0;
for (int i = 0; i < 3; i++)
    result += dp[n - 1, i];
result %= mod;
Console.WriteLine(result);