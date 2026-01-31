int[] alpha = { 3, 2, 1, 2, 4, 3, 1, 3, 1, 1, 3, 1, 3, 2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 2, 2, 1 };
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
string[] names = Console.ReadLine().Split();
int size = names[0].Length + names[1].Length;
int[,] dp = new int[size, size];
int index = 0;
int i = 0;
int j = 0;
while (index < size)
{
    if (i < names[0].Length)
        dp[0, index++] = alpha[names[0][i++] - 'A'];
    if (j < names[1].Length)
        dp[0, index++] = alpha[names[1][j++] - 'A'];
}

for (i = 1; i < size - 1; i++)
{
    for (j = 0; j < size - i; j++)
    {
        dp[i, j] = dp[i - 1, j] + dp[i - 1, j + 1];
        dp[i, j] %= 10;
    }
}
if (dp[size - 2, 0] != 0)
    Console.Write("{0}", dp[size - 2, 0]);
Console.WriteLine($"{dp[size - 2, 1]}%");