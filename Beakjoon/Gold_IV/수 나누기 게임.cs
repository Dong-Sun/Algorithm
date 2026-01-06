using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            bool[] keys = new bool[1000005];
            int[] count = new int[1000005];
            int n = int.Parse(Console.ReadLine());
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            foreach (var v in input)
                keys[v] = true;
            foreach (var v in input)
            {
                for (int i = v + v; i <= 1000000; i += v)
                {
                    if (keys[i])
                    {
                        count[v]++;
                        count[i]--;
                    }
                }
            }
            foreach (var v in input)
                sb.Append(count[v] + " ");
            Console.WriteLine(sb);
        }
    }
}