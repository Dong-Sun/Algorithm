using System.Text;

// input
StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int c = 1;
while (c <= t)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int n = input[0];
    int k = input[1];
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    // solution
    long result = 0;
    int[] index = Enumerable.Repeat(-1, 500001).ToArray();
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = input[i]; j <= input[i] + k; j++)
        {
            if (j >= index.Length)
                break;
            if (index[j] != -1)
                j = input[index[j]] + k;
            else
                index[j] = i;
        }
    }
    for (int i = 0; i < input.Length; i++)
        result += i - index[input[i]];

    sb.AppendLine($"Case #{c++}");
    sb.AppendLine(result.ToString());
}

// print
Console.Write(sb);