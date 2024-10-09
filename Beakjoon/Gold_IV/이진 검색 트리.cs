using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static int[,] tree;
        static void Main(string[] args)
        {
            tree = new int[1000001, 2];
            int root = InputInt();
            int t = 8;
            while (true)
            {
                int temp = 0;
                if (!int.TryParse(Console.ReadLine(), out temp))
                    break;
                int node = root;
                while (true)
                {
                    if (temp < node)
                    {
                        // left
                        if (tree[node, 0] != 0)
                            node = tree[node, 0];
                        else
                        {
                            tree[node, 0] = temp;
                            break;
                        }
                    }
                    else
                    {
                        // right
                        if (tree[node, 1] != 0)
                            node = tree[node, 1];
                        else
                        {
                            tree[node, 1] = temp;
                            break;
                        }
                    }
                }
                t--;
            }
            Dfs(root);
            Console.Write(sb);
        }
        static void Dfs(int cur)
        {
            if (tree[cur, 0] != 0)
                Dfs(tree[cur, 0]);
            if (tree[cur, 1] != 0)
                Dfs(tree[cur, 1]);
            sb.AppendLine($"{cur}");
        }
    }
}