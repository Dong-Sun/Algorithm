using System.Text;
StringBuilder sb = new StringBuilder();
// 입력
List<int> result = new List<int>();
int n = int.Parse(Console.ReadLine());
int[] arr = new int[n + 1];
for (int i = 1; i <= n; i++)
    arr[i] = int.Parse(Console.ReadLine());
// 구현
int[] visited = new int[n + 1];
for (int i = 1; i <= n; i++)
    Dfs(i);
void Dfs(int index)
{
    if (visited[index] == 2)
        return;
    if (visited[index] == 1)
    {
        result.Add(index);
        int i = index;
        while (arr[i] != index)
        {
            i = arr[i];
            result.Add(i);
        }
        return;
    }
    visited[index] = 1;
    Dfs(arr[index]);
    visited[index] = 2;
}
result.Sort();
// 출력
sb.AppendLine(result.Count.ToString());
foreach (var v in result)
    sb.AppendLine(v.ToString());
Console.Write(sb);