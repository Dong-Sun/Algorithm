namespace CSharp
{
    class Program
    {
        static int n;
        static int[] arr;
        static int[] oper;
        static int max = int.MinValue;
        static int min = int.MaxValue;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            oper = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            BackTracking(1, arr[0]);
            Console.WriteLine(max);
            Console.WriteLine(min);
        }
        static void BackTracking(int depth, int result)
        {
            if (depth >= n)
            {
                max = Math.Max(max, result);
                min = Math.Min(min, result);
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                if (oper[i] > 0)
                {
                    oper[i]--;
                    if (i == 0) BackTracking(depth + 1, result + arr[depth]);
                    else if (i == 1) BackTracking(depth + 1, result - arr[depth]);
                    else if (i == 2) BackTracking(depth + 1, result * arr[depth]);
                    else BackTracking(depth + 1, result / arr[depth]);
                    oper[i]++;
                }
            }
        }
    }
}