using System.Text;

StringBuilder sb = new StringBuilder();
uint[] input = Array.ConvertAll(Console.ReadLine().Split(), uint.Parse);
int n = (int)input[0];  // 비트 수
int l = (int)input[1];  // 값이 1인 비트의 최대 개수
long k = input[2];      // 크기 순으로 나열했을 때 k번째

// dp
long[,] dp = new long[n + 1, l + 1];
for (int i = 0; i <= l; i++)
    dp[0, i] = 1;

for (int i = 1; i <= n; i++)
{
    dp[i, 0] = 1;
    for (int j = 1; j <= l; j++)
    {
        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
    }
}

// 이진수 찾기
int[] result = new int[n];
for (int i = n - 1; i >= 0; i--)
{
    if (l <= 0) break;

    if (k > dp[i, l])
    {
        result[n - 1 - i] = 1;
        k -= dp[i, l];
        l -= 1;
    }
    else
    {
        result[n - 1 - i] = 0;
    }
}

for (int i = 0; i < n; i++)
    sb.Append(result[i]);
Console.WriteLine(sb);