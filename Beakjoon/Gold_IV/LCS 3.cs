string[] s = new string[3];
for (int i = 0; i < 3; i++)
    s[i] = Console.ReadLine();

int[,,] dp = new int[101, 101, 101];
Lcs();
Console.WriteLine(dp[s[0].Length, s[1].Length, s[2].Length]);

void Lcs()
{
    for (int i = 1; i <= s[0].Length; i++)
    {
        for (int j = 1; j <= s[1].Length; j++)
        {
            for (int k = 1; k <= s[2].Length; k++)
            {
                if (s[0][i - 1] == s[1][j - 1] && s[0][i - 1] == s[2][k - 1])
                    dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                else
                    dp[i, j, k] = Math.Max(dp[i - 1, j, k], Math.Max(dp[i, j - 1, k], dp[i, j, k - 1]));
            }
        }
    }
}