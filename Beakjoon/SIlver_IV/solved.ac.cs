namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution();
        }

        public static void Solution()
        {
            int N = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(Console.ReadLine());
            Array.Sort(arr);
            double d = N * 0.15;
            int trim = (int)d;
            if (d - (int)d >= 0.5)
                trim++;
            double result = 0;
            for (int i = trim; i < N - trim; i++)
                result += arr[i];
            d = result / (N - trim * 2);
            int ans = (int)d;
            if (d - (int)d >= 0.5)
                ans++;
            if (N == 0)
            {
                Console.WriteLine("0");
            }
            else
                Console.WriteLine(ans);
        }
    }
}