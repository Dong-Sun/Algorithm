using System.Text;
int n = int.Parse(Console.ReadLine());
string[] input;
int[,] dp = new int[201, 201];
StringBuilder sb = new StringBuilder();
for (int i = 1; i <= n; i++)
{
    for (int y = 0; y < 201; y++)
        for (int x = 0; x < 201; x++)
            dp[y, x] = -1;

    input = Console.ReadLine().Split();

    if (Dfs(0, 0, 0) == 1)
        sb.AppendLine("Data set " + i + ": yes");
    else
        sb.AppendLine("Data set " + i + ": no");
}
Console.Write(sb);

int Dfs(int index1, int index2, int index3)
{
    if (index3 == input[2].Length)
        return 1;

    int temp = dp[index1, index2];
    if (temp != -1)
        return temp;

    temp = 0;
    if (index1 < input[0].Length && input[0][index1] == input[2][index3])
        temp = Dfs(index1 + 1, index2, index3 + 1);
    if (index2 < input[1].Length && input[1][index2] == input[2][index3])
        temp |= Dfs(index1, index2 + 1, index3 + 1);
    dp[index1, index2] = temp;
    return temp;
}