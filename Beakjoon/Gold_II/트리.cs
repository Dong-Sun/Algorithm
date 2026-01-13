using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static int t;
        static int n;
        static int[] Preorder;
        static int[] Inorder;
        static int[,] tree;
        static int[] index;
        static string[] split;
        static void Main(string[] args)
        {
            // 입력
            t = int.Parse(sr.ReadLine());
            while (t-- > 0)
            {
                n = int.Parse(sr.ReadLine());
                Preorder = new int[n];
                Inorder = new int[n];
                int idx = 0;
                split = sr.ReadLine().Split();
                for (int i = 0; i < split.Length; i++)
                {
                    if (string.IsNullOrEmpty(split[i])) continue;
                    Preorder[idx++] = int.Parse(split[i]);
                }
                idx = 0;
                split = sr.ReadLine().Split();
                for (int i = 0; i < split.Length; i++)
                {
                    if (string.IsNullOrEmpty(split[i])) continue;
                    Inorder[idx++] = int.Parse(split[i]);
                }
                tree = new int[n + 1, 2];
                index = new int[n + 1];
                for (int i = 0; i < n; i++)
                    index[Inorder[i]] = i;

                // 구현
                int root = Preorder[0];
                for (int i = 1; i < n; i++)
                    Dfs(Preorder[i], root);

                // 출력
                PostOrder(root);
                sb.AppendLine();
            }
            Console.Write(sb);
        }
        static void Dfs(int node, int parent)
        {
            if (index[node] < index[parent])
            {
                if (tree[parent, 0] == 0)
                    tree[parent, 0] = node;
                else
                    Dfs(node, tree[parent, 0]);
            }
            else
            {
                if (tree[parent, 1] == 0)
                    tree[parent, 1] = node;
                else
                    Dfs(node, tree[parent, 1]);
            }
        }
        static void PostOrder(int node)
        {
            if (tree[node, 0] != 0)
                PostOrder(tree[node, 0]);
            if (tree[node, 1] != 0)
                PostOrder(tree[node, 1]);
            sb.Append(node.ToString() + " ");
        }
    }
}