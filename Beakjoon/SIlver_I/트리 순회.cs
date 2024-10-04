using System.Text;

namespace Solution
{
    class Program
    {
        static char[,] tree;
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            tree = new char[n, 2];
            int temp = n;
            while (temp > 0)
            {
                string[] split = Console.ReadLine().Split();
                int index = split[0][0] - 65;
                tree[index, 0] = split[1][0];
                tree[index, 1] = split[2][0];
                temp--;
            }
            Preorder('A');
            sb.AppendLine();
            Inorder('A');
            sb.AppendLine();
            Postorder('A');
            Console.WriteLine(sb);
        }
        static void Preorder(char alpha)
        {
            sb.Append(alpha);
            if (!tree[alpha - 65, 0].Equals('.'))
                Preorder(tree[alpha - 65, 0]);
            if (!tree[alpha - 65, 1].Equals('.'))
                Preorder(tree[alpha - 65, 1]);
        }
        static void Inorder(char alpha)
        {
            if (!tree[alpha - 65, 0].Equals('.'))
                Inorder(tree[alpha - 65, 0]);
            sb.Append(alpha);
            if (!tree[alpha - 65, 1].Equals('.'))
                Inorder(tree[alpha - 65, 1]);
        }
        static void Postorder(char alpha)
        {
            if (!tree[alpha - 65, 0].Equals('.'))
                Postorder(tree[alpha - 65, 0]);
            if (!tree[alpha - 65, 1].Equals('.'))
                Postorder(tree[alpha - 65, 1]);
            sb.Append(alpha);
        }
    }
}