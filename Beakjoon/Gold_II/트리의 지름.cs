namespace CSharp
{
    class Program
    {
        static bool[] visited;
        static List<List<(int, int)>> tree;
        static int result = 0;
        static int leaf;
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            tree = new List<List<(int, int)>>(v + 1);   // next, dist
            for (int i = 0; i <= v; i++)
                tree.Add(new List<(int, int)>());

            for (int i = 0; i < v; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int vertex = input[0];
                int next = 1;
                int dist = 2;
                while (input[next] != -1)
                {
                    tree[vertex].Add((input[next], input[dist]));
                    next += 2;
                    dist += 2;
                }
            }
            visited = new bool[v + 1];
            // 리프노드 찾기
            Dfs(1, 0);
            // dfs
            Dfs(leaf, 0);

            Console.WriteLine(result);
        }
        static void Dfs(int start, int depth)
        {
            visited[start] = true;
            if (result < depth)
            {
                result = depth;
                leaf = start;
            }
            for (int i = 0; i < tree[start].Count; i++)
            {
                if (visited[tree[start][i].Item1] == false)
                    Dfs(tree[start][i].Item1, depth + tree[start][i].Item2);
            }
            visited[start] = false;
        }
    }
}