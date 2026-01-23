int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
long[,] dp = new long[n + 1, n + 1];
dp[0, 0] = 1;
for (int i = 0; i <= n; i++)
    for (int j = 1; j <= i; j++)
        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
Console.WriteLine(dp[n, k]);