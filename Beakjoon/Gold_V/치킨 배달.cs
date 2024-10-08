namespace Debug
{
    class Program
    {
        static int n;
        static int m;
        static int result = int.MaxValue;
        static int[,] distance;
        static int[] select;
        static bool[] visited;
        static List<(int, int)> home;
        static List<(int, int)> chicken;
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static void Main(string[] args)
        {
            int[] arr = InputIntArray.Invoke();
            n = arr[0];
            m = arr[1];
            home = new List<(int, int)>();
            chicken = new List<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                arr = InputIntArray.Invoke();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == 1)
                        home.Add((i, j));
                    if (arr[j] == 2)
                        chicken.Add((i, j));
                }
            }
            select = new int[m];
            visited = new bool[chicken.Count];
            distance = new int[home.Count, chicken.Count];
            for (int i = 0; i < home.Count; i++)
            {
                for (int j = 0; j < chicken.Count; j++)
                {
                    distance[i, j] = Math.Abs(home[i].Item1 - chicken[j].Item1) + Math.Abs(home[i].Item2 - chicken[j].Item2);
                }
            }
            for (int i = 0; i < chicken.Count; i++)
                Dfs(0, i);

            Console.WriteLine(result);
        }

        static void Dfs(int depth, int cur)
        {
            select[depth] = cur;
            if (depth == m - 1)
            {
                int sum = 0;
                for (int i = 0; i < home.Count; i++)
                {
                    int min = int.MaxValue;
                    foreach (var v in select)
                    {
                        min = Math.Min(min, distance[i, v]);
                    }
                    sum += min;
                }
                if (sum < result)
                    result = sum;
                return;
            }
            for (int i = cur + 1; i < chicken.Count; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    Dfs(depth + 1, i);
                    visited[i] = false;
                }
            }
        }
    }
}