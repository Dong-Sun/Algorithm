using System.Text;

namespace CSharp
{
    class Program
    {
        static Dictionary<string, string> edges = new Dictionary<string, string>();
        static Dictionary<string, int> count = new Dictionary<string, int>();
        static Dictionary<string, int> rank = new Dictionary<string, int>();
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                int f = int.Parse(Console.ReadLine());
                while (f-- > 0)
                {
                    string[] split = Console.ReadLine().Split(' ');
                    string a = split[0];
                    string b = split[1];
                    if (!edges.ContainsKey(a))
                    {
                        edges.Add(a, a);
                        count.Add(a, 1);
                        rank.Add(a, 1);
                    }
                    if (!edges.ContainsKey(b))
                    {
                        edges.Add(b, b);
                        count.Add(b, 1);
                        rank.Add(b, 1);
                    }

                    Union(a, b);

                    sb.AppendLine(count[Find(a)].ToString());
                }
                edges.Clear();
                count.Clear();
                rank.Clear();
            }
            Console.WriteLine(sb);
        }
        static string Find(string s)
        {
            if (s != edges[s])
                edges[s] = Find(edges[s]);
            return edges[s];
        }
        static void Union(string a, string b)
        {
            string left = Find(a);
            string right = Find(b);
            if (left == right)
                return;

            count[left] += count[right];
            count[right] = count[left];

            if (rank[left] == rank[right])
            {
                edges[right] = left;
                rank[left]++;
            }
            else if (rank[left] > rank[right])
                edges[right] = left;
            else
                edges[left] = right;
        }
    }
}