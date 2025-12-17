namespace CSharp
{
    class Program
    {
        static Dictionary<long, long> d = new Dictionary<long, long>();
        static long mod = 1000000007;
        static void Main(string[] args)
        {
            // init
            long n = long.Parse(Console.ReadLine());
            System.Console.WriteLine(Fibo(n));
        }
        static long Fibo(long n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            if (d.ContainsKey(n)) return d[n];
            if (n % 2 == 0) d.Add(n, Fibo(n / 2) * (Fibo(n / 2 + 1) + Fibo(n / 2 - 1)));
            else d.Add(n, Fibo((n + 1) / 2) * Fibo((n + 1) / 2) + Fibo((n - 1) / 2) * Fibo((n - 1) / 2));
            d[n] = d[n] % mod;
            return d[n];
        }
    }
}