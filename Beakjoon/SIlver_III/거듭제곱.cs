using System.Text;

namespace Debug
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long k = 1;
            long sum = 0;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    sum += k;
                }
                n /= 2;
                k *= 3;
            }
            Console.WriteLine(sum);
        }
    }
}