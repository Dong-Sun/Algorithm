using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[] result = new int[n];
            int count = 0;
            int cur = 1;
            while (count < n && cur <= 1000)
            {
                for (int i = 0; i < n; i++)
                {
                    if (cur == a[i])
                    {
                        result[i] = count;
                        count++;
                    }
                }
                cur++;
            }
            foreach (int num in result)
                Console.Write("{0} ", num);
        }
    }
}