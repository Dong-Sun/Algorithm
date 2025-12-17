namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // init
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int min = int.MaxValue;
            int[] result = new int[2];
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                int temp = arr[left] + arr[right];
                if (Math.Abs(temp) < min)
                {
                    min = Math.Abs(temp);
                    result[0] = arr[left];
                    result[1] = arr[right];
                }
                if (temp < 0)
                    left++;
                else if (temp > 0)
                    right--;
                else
                    break;
            }
            Console.WriteLine("{0} {1}", result[0], result[1]);
        }
    }
}