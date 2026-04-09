using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int n = 0;
int[] arr;
while (t-- > 0)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
    n = input[0];
    arr = new int[n];
    for (int i = 0; i < n; i++)
        arr[i] = input[i + 1];

    long result = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            int a = Math.Max(arr[i], arr[j]);
            int b = Math.Min(arr[i], arr[j]);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            result += a;
        }
    }
    sb.AppendLine(result.ToString());
}
Console.Write(sb);