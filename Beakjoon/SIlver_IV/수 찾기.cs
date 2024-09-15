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
            string[] split = Console.ReadLine().Split();
            int[] arr = new int[N];
            for (int i = 0; i < split.Length; i++)
            {
                arr[i] = int.Parse(split[i]);
            }
            Array.Sort(arr);
            int M = int.Parse(Console.ReadLine());
            split = Console.ReadLine().Split();
            for (int i = 0; i < split.Length; i++)
            {
                int num = int.Parse(split[i]);
                if (Array.BinarySearch(arr, num) >= 0)
                    System.Console.WriteLine("1");
                else
                    System.Console.WriteLine("0");
            }
        }
    }
}