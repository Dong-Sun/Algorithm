using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static Tree tree;
        static int n;
        static int result = 0;
        static void Main(string[] args)
        {
            n = InputInt();
            tree = new Tree(n + 1);
            int temp = n - 1;
            while (temp > 0)
            {
                int[] input = InputIntArray();
                tree.Add(input[0], input[1], input[2]);
                tree.Add(input[1], input[0], input[2]);
                temp--;
            }
            for (int i = n; i >= n / 2; i--)
                Dfs(i, 0);
            Console.WriteLine(result);
        }
        static void Dfs(int node, int sum)
        {
            if (!tree.IsMove(node))
            {
                if (sum > result)
                    result = sum;
                return;
            }
            tree.visited[node] = true;
            foreach (var v in tree.edge[node])
            {
                if (!tree.visited[v.Item1])
                {
                    Dfs(v.Item1, sum + v.Item2);
                }
            }
            tree.visited[node] = false;
        }
    }
    public class Tree
    {
        public List<List<(int, int)>> edge = new List<List<(int, int)>>();
        public bool[] visited;
        public Tree(int size)
        {
            for (int i = 0; i < size; i++)
                edge.Add(new List<(int, int)>());
            visited = new bool[size];
        }
        public void Add(int start, int end, int weight)
        {
            edge[start].Add((end, weight));
        }
        public bool IsMove(int node)
        {
            bool isMove = false;
            foreach (var e in edge[node])
            {
                if (!visited[e.Item1])
                    isMove = true;
            }
            return isMove;
        }
    }
}