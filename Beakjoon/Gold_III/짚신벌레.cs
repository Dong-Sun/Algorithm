// input
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int d = input[2];
int n = input[3];

// solution
int[] dp = new int[n + 1];
for (int i = 0; i < a; i++)
    dp[i] = 1;
for (int i = a; i <= n; i++)
{
    if (i - b < 0)
        dp[i] = dp[i - 1] + dp[i - a];
    else
        dp[i] = dp[i - 1] + dp[i - a] - dp[i - b] + 1000;
    dp[i] %= 1000;
}

// print
if (n - d < 0)
    Console.WriteLine(dp[n]);
else
    Console.WriteLine((dp[n] - dp[n - d] + 1000) % 1000);