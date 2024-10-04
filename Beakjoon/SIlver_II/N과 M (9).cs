using System.Text;

namespace Solution
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static int n;
        static int m;
        static bool[] visited;
        static int[] arr;
        static List<int> list;
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split(' ');
            n = int.Parse(split[0]);
            m = int.Parse(split[1]);
            arr = new int[m];
            visited = new bool[n + 2];
            split = Console.ReadLine().Split(' ');
            list = new List<int>(n + 1);
            for (int i = 0; i < split.Length; i++)
                list.Add(int.Parse(split[i]));
            list.Sort();

            Dfs(0);
            Console.Write(sb);
        }
        static void Dfs(int depth)
        {
            if (depth == m)
            {
                foreach (int num in arr)
                {
                    sb.Append($"{num} ");
                }
                sb.AppendLine();
                return;
            }
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i] || temp == list[i])
                    continue;
                visited[i] = true;
                arr[depth] = list[i];
                temp = list[i];
                Dfs(depth + 1);
                visited[i] = false;
            }
        }
    }
}