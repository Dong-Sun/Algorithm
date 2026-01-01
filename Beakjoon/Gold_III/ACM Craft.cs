using System.Text;

namespace CSharp
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static Func<int[]> InputIntArray = () => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        static Func<int> InputInt = () => int.Parse(Console.ReadLine());
        static List<List<int>> edges;   // 간선
        static int[] inDegree;  // 진입차수
        static int t;   // 테스트케이스
        static int n;   // 건물의 개수
        static int k;   // 건설순서 규칙의 총 개수
        static int[] delays;    // 각 건물당 건설에 걸리는 시간
        static int w;   // 승리하기 위해 건설해야 할 건물의 번호
        static int[] input;
        static Queue<int> q;
        static int[] result;
        static void Main(string[] args)
        {
            t = InputInt();
            while (t-- > 0)
            {
                Initialize();
                Solution();
                sb.AppendLine(result[w].ToString());
            }
            Console.WriteLine(sb);
        }
        static void Initialize()
        {
            input = InputIntArray();
            n = input[0];
            k = input[1];
            input = InputIntArray();
            delays = new int[n + 1];
            for (int i = 0; i < n; i++)
                delays[i + 1] = input[i];
            edges = new List<List<int>>(n + 1);
            for (int i = 0; i <= n; i++)
                edges.Add(new List<int>());
            result = new int[n + 1];
            inDegree = new int[n + 1];
            while (k-- > 0)
            {
                input = InputIntArray();
                int x = input[0];
                int y = input[1];
                edges[x].Add(y);
                inDegree[y]++;
            }
            w = InputInt();
            q = new Queue<int>();
        }
        static void Solution()
        {
            for (int i = 1; i <= n; i++)
                if (inDegree[i] == 0)
                {
                    q.Enqueue(i);
                    result[i] = delays[i];
                }
            for (int i = 0; i < n; i++)
            {
                int cur = q.Dequeue();
                foreach (var v in edges[cur])
                {
                    result[v] = Math.Max(result[v], result[cur] + delays[v]);
                    if (--inDegree[v] == 0)
                        q.Enqueue(v);
                }
            }
        }
    }
}