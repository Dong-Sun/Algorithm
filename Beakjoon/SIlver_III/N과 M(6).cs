using System.Text;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr);

int[] result = new int[m];
StringBuilder sb = new StringBuilder();
Dfs(0, 0);
Console.Write(sb);

void Dfs(int depth, int index)
{
    if (depth == m)
    {
        for (int i = 0; i < m; i++)
            sb.Append($"{result[i]} ");
        sb.AppendLine();
        return;
    }
    for (int i = index; i < n; i++)
    {
        result[depth] = arr[i];
        Dfs(depth + 1, i + 1);
    }
}