using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = arr[0];
            int b = arr[1];
            int n = int.Parse(Console.ReadLine());

            int start = a;
            int dist = Math.Abs(b - start);
            while (n > 0)
            {
                int temp = int.Parse(Console.ReadLine());
                if (dist > Math.Abs(b - temp) + 1)
                {
                    start = temp;
                    dist = Math.Abs(b - start) + 1;
                }
                n--;
            }
            Console.WriteLine(dist);
        }
    }
}