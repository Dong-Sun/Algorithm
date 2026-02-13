// input
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];   // 학생 수
int m = input[1];   // 최대 소지 가능한 블록 수
int h = input[2];   // 쌓고자 하는 높이
int[][] list = new int[n + 1][];
list[0] = new int[h + 1];
for (int i = 1; i <= n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list[i] = new int[input.Length];
    for (int j = 0; j < input.Length; j++)
        list[i][j] = input[j];
}

// solution
// dp[i, j] = i번 학생까지 블록을 쌓을 때 j높이 만큼 쌓는 경우의 수
int[,] dp = new int[n + 1, h + 1];
dp[0, 0] = 1;   // 선택하지 않는 경우를 위한 초기화

for (int i = 1; i <= n; i++)
{
    for (int j = 0; j <= h; j++)
    {
        // i번째 학생이 블럭을 선택하지 않는 경우
        dp[i, j] = dp[i - 1, j];

        foreach (int v in list[i])
        {
            if (j - v < 0) continue;
            // 블럭을 선택할 때 이전 경우의 수를 불러오기
            dp[i, j] += dp[i - 1, j - v];
            dp[i, j] %= 10007;
        }
    }
}

// print
Console.WriteLine(dp[n, h]);