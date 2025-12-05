using System.Runtime.InteropServices;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine()); // 주사위의 수
            long mod = 1000000007;
            long result = 0;
            while (m > 0)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int n = input[0];   // 해당 주사위 면의 갯수
                int s = input[1];   // 해당 주사위 합
                long temp = n;
                long num = 1;
                long pow = 1000000005;
                while (pow > 0)
                {
                    if (pow % 2 == 1)
                        num = num * temp % mod;

                    temp = temp * temp % mod;
                    pow = pow / 2;
                }
                result = (result + (num * s % mod)) % mod;
                m--;
            }
            Console.WriteLine(result);
        }
    }
}