using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static List<List<int>> tree;
        static int index = 1;
        static int[,] where;
        static void Main(string[] args)
        {
            // init
            int n = InputInt();
            int[] input;
            where = new int[n + 1, 2];
            tree = new List<List<int>>(n + 1);
            for (int i = 0; i <= n; i++)
                tree.Add(new List<int>());
            for (int j = 0; j < n; j++)
            {
                input = InputIntArray();
                int cur = input[0];
                for (int i = 1; input[i] != -1; i++)
                    tree[cur].Add(input[i]);
            }
            for (int i = 1; i <= n; i++)
                tree[i].Sort();
            int root = InputInt();

            // solution
            Search(root, 0);

            // print
            for (int i = 1; i <= n; i++)
            {
                sb.Append(i + " ");
                sb.Append(where[i, 0] + " ");
                sb.Append(where[i, 1] + "\n");
            }
            Console.Write(sb);
        }
        static void Search(int n, int parent)
        {
            where[n, 0] = index++;
            foreach (var next in tree[n])
            {
                if (next != parent)
                    Search(next, n);
            }
            where[n, 1] = index++;
        }
    }
}