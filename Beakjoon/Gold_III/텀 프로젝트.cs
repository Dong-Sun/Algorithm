using System.Text;

namespace CSharp
{
    class Program
    {
        static int n;
        static int[] input;
        static int[] arr = new int[100001];
        static int[] visited = new int[100001];
        static int count = 0;
        static StringBuilder sb = new StringBuilder();
        static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static void Main(string[] args)
        {
            int t = int.Parse(sr.ReadLine());
            while (t-- > 0)
            {
                n = int.Parse(sr.ReadLine());
                input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int i = 0; i < input.Length; i++)
                    arr[i + 1] = input[i];
                for (int i = 1; i <= n; i++)
                    visited[i] = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (visited[i] == 2)
                        continue;
                    Dfs(i, 1);
                }
                sb.AppendLine(count.ToString());
                count = 0;
            }
            sw.WriteLine(sb);
        }
        static void Dfs(int index, int depth)
        {
            if (visited[index] == 2)
            {
                count += depth - 1;
                return;
            }
            visited[index] = 1;
            if (visited[arr[index]] == 1)
            {
                visited[index] = 2;
                int i = arr[index];
                int cnt = 1;
                while (i != index)
                {
                    i = arr[i];
                    cnt++;
                }
                count += depth - cnt;
                return;
            }
            Dfs(arr[index], depth + 1);
            visited[index] = 2;
        }
    }
}