using System.Text;

namespace Solution
{
    class Program
    {
        static int n;
        static int m;
        static int[] arr;
        static List<int> list;
        static bool[] visited;
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            string[] split = Console.ReadLine().Split(' ');
            n = int.Parse(split[0]);
            m = int.Parse(split[1]);
            split = Console.ReadLine().Split(' ');
            list = new List<int>();
            visited = new bool[n + 2];
            arr = new int[m];
            foreach (string s in split)
            {
                list.Add(int.Parse(s));
            }
            list.Sort();
            Dfs(0);
            Console.Write(sb);
        }
        static void Dfs(int depth)
        {
            if (depth == m)
            {
                foreach (int n in arr)
                {
                    sb.Append($"{n} ");
                }
                sb.AppendLine();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                    continue;
                visited[i] = true;
                arr[depth] = list[i];
                Dfs(depth + 1);
                visited[i] = false;
            }
        }
    }
}