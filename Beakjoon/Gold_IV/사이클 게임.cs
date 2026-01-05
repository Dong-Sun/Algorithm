namespace CSharp
{
    class Program
    {
        static int[] parent;
        static int[] level;
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = input[0];
            int m = input[1];
            parent = new int[n];
            level = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                level[i] = 1;
            }
            int cnt = 0;
            int result = 0;
            while (m-- > 0)
            {
                cnt++;
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int a = input[0];
                int b = input[1];
                if (!Union(a, b))
                {
                    result = cnt;
                    break;
                }
            }
            Console.WriteLine(result);
        }
        static int Find(int num)
        {
            if (num != parent[num])
                parent[num] = Find(parent[num]);
            return parent[num];
        }
        static bool Union(int a, int b)
        {
            int left = Find(a);
            int right = Find(b);
            if (left == right)  // cycle
                return false;
            if (level[left] > level[right])
                parent[right] = left;
            else if (level[left] < level[right])
                parent[left] = right;
            else
            {
                parent[right] = left;
                level[left]++;
            }
            return true;
        }
    }
}