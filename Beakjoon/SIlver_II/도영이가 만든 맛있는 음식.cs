int n = int.Parse(Console.ReadLine()!);
int[,] table = new int[n, 2];

for (int i = 0; i < n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
    int s = input[0];
    int b = input[1];
    table[i, 0] = s;
    table[i, 1] = b;
}

int k = 1 << n;
int result = int.MaxValue;
for (int i = 1; i < k; i++)
{
    int s = 1;
    int b = 0;
    for (int j = 0; j < n; j++)
    {
        if ((i & 1 << j) > 0)
        {
            s *= table[j, 0];
            b += table[j, 1];
        }
    }
    result = Math.Min(result, Math.Abs(s - b));
}
Console.WriteLine(result);