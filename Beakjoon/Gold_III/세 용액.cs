namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            Array.Sort(arr);
            int left;
            int right;
            long min = long.MaxValue;
            long[] result = new long[3];
            for (int i = 1; i < n - 1; i++)
            {
                left = i - 1;
                right = i + 1;
                while (left >= 0 && right < n)
                {
                    if (Math.Abs(min) > Math.Abs(arr[i] + arr[left] + arr[right]))
                    {
                        min = arr[i] + arr[left] + arr[right];
                        result[0] = arr[left];
                        result[1] = arr[i];
                        result[2] = arr[right];
                    }
                    if (arr[i] + arr[left] + arr[right] > 0)
                        left--;
                    else if (arr[i] + arr[left] + arr[right] < 0)
                        right++;
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", arr[left], arr[i], arr[right]);
                        return;
                    }
                }
            }
            Console.WriteLine("{0} {1} {2}", result[0], result[1], result[2]);
        }
    }
}