int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int[] result = new int[n];
bool[] visited = new bool[n];
int index = 0;
while (index < n)
{
    for (int i = 0; i < n; i++)
    {
        if (visited[i])
            continue;
        if (arr[i] <= 0)
        {
            result[index] = i + 1;
            visited[i] = true;
            for (int j = i - 1; j >= 0; j--)
            {
                if (visited[j])
                    continue;
                arr[j]--;
            }
            break;
        }
    }
    index++;
}
foreach (var v in result)
    Console.Write($"{v} ");