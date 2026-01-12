using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static StreamReader sr = new StreamReader(Console.OpenStandardInput());
        static int gate;
        static int plane;
        static int[] parent;
        static int result = 0;
        static void Main(string[] args)
        {
            // 입력
            gate = int.Parse(sr.ReadLine());
            plane = int.Parse(sr.ReadLine());
            parent = new int[gate + 1];
            for (int i = 1; i <= gate; i++)
                parent[i] = i;

            // 구현
            for (int i = 0; i < plane; i++)
            {
                int cur = int.Parse(sr.ReadLine());
                bool able = Union(cur);
                if (able) result++;
                else break;
            }

            // 출력
            Console.WriteLine(result);
        }
        static int Find(int cur)
        {
            if (cur != parent[cur])
                parent[cur] = Find(parent[cur]);
            return parent[cur];
        }
        static bool Union(int cur)
        {
            int next = Find(cur);
            if (next == 0)
                return false;
            parent[next] = next - 1;
            return true;

        }
    }
}