// input
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

// solution
int[,] table = new int[n + 1, n + 1];
table[0, 0] = 1;
for (int i = 1; i <= n; i++)
{
    table[i, 0] = 1;
    for (int j = 1; j <= i; j++)
    {
        table[i, j] = table[i - 1, j - 1] + table[i - 1, j];
    }
}

int sum = 0;
for (int i = k; i <= m; i++)
{
    sum += table[m, i] * table[n - m, m - i];
}

double d = (double)sum / (double)table[n, m];

// print
Console.WriteLine(d);