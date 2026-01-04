namespace CSharp
{
    class Program
    {
        static int n;
        static int m;
        static int[] arr;
        static bool[] unable;
        static int minDistance;
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            n = int.Parse(s);
            m = int.Parse(Console.ReadLine());
            if (m > 0)
                arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            unable = new bool[10];
            for (int i = 0; i < m; i++)
                unable[arr[i]] = true;
            minDistance = Math.Abs(n - 100);
            for (int i = 0; i <= 1000000; i++)
            {
                var item = Direct(i.ToString());
                if (item.Item1)
                    minDistance = Math.Min(minDistance, Math.Abs(n - i) + item.Item2);
            }
            Console.WriteLine(minDistance);
        }
        static (bool, int) Direct(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (unable[int.Parse(s[i].ToString())]) return (false, 0);
            return (true, s.Length);
        }
    }
}