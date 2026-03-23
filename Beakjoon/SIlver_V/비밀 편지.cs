using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine()!);
while (t-- > 0)
{
    string input = Console.ReadLine();
    int size = input.Length;
    int r = (int)Math.Sqrt(size);
    int c = r;
    char[,] table = new char[r, c];
    for (int i = 0; i < r; i++)
        for (int j = 0; j < c; j++)
            table[i, j] = input[i * c + j];
    for (int i = c - 1; i >= 0; i--)
        for (int j = 0; j < r; j++)
            sb.Append(table[j, i]);
    sb.Append('\n');
}
Console.WriteLine(sb);