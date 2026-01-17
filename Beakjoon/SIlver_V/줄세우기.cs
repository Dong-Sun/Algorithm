using System.Text;
// 입력
StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
int[,] arr = new int[n + 1, 20];
for (int i = 1; i <= n; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j < input.Length; j++)
    {
        arr[i, j - 1] = input[j];
    }
}
// 구현
for (int i = 1; i <= n; i++)
{
    int count = 0;
    for (int j = 0; j < 20; j++)
    {
        int num = arr[i, j];
        for (int k = j; k > 0; k--)
        {
            if (arr[i, k] < arr[i, k - 1])
            {
                int temp = arr[i, k];
                arr[i, k] = arr[i, k - 1];
                arr[i, k - 1] = temp;
                count++;
            }
        }
    }
    sb.AppendLine(i + " " + count);
}
// 출력
Console.WriteLine(sb);